using GChatBot.Data.Records;
using GChatBot.Services.RabbitMqServices;
using GChatBot.Data;
using GChatBot.Data.Constants;
using GChatBot.Services.ChatServices;
using Microsoft.EntityFrameworkCore;
using GChatBot.Services.UserServices;
using Microsoft.Extensions.Options;

namespace GChatBot.Worker.HostServices;

    public class BotRequestBackgroundService : IHostedService
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IStockService _stockService;
        private readonly IUserService _userService;
        private readonly GChatBotDbContext _dbContext;
        private readonly StockOptions _stockOptions;

        public BotRequestBackgroundService(
            IRabbitMqService rabbitMqService,
            IDbContextFactory<GChatBotDbContext> dbContext,
            IStockService stockService,
            IUserService userService,
            IOptions<StockOptions> stockOptions)
        {
            _rabbitMqService = rabbitMqService;
            _stockService = stockService;
            _userService = userService;
            _dbContext = dbContext.CreateDbContext();
            _stockOptions = stockOptions.Value;

            if (string.IsNullOrWhiteSpace(_stockOptions?.Url))
                throw new ArgumentNullException(nameof(_stockOptions.Url));
        }

        private async Task ResolveStockCode(CommandInformation command, CancellationToken ct = default)
        {
            var message = command.Command switch
            {
                BotCommands.StockCommand => await _stockService.GetStockMessage(_stockOptions.Url, command.Parameter, ct),
                _ => $"CommandInfo {command} is not a Stock Command"
            };

            var entry = _dbContext.ChatMessages.Add(new GChatBot.Data.Entities.ChatMessage
            {
                Message = message,
                UserId = BotConstants.Id,
                CreatedAt = DateTime.Now
            });

            await _dbContext.SaveChangesAsync(ct);
            await _rabbitMqService.Produce(QueueNames.Chat, entry.Entity, ct);
        }

        public async Task StartAsync(CancellationToken ct) => await _rabbitMqService.Consume<CommandInformation>(QueueNames.Bot, ResolveStockCode, ct);

        public Task StopAsync(CancellationToken ct)
        {
            _rabbitMqService.Dispose();
            return Task.CompletedTask;
        }
    }
