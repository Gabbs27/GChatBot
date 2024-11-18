using GChatBot.Data.Constants;
using GChatBot.Data.Entities;
using GChatBot.Services.RabbitMqServices;
using GChatBot.WebApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GChatBot.WebApi.HostServices;

    public class BotResponseBackgroundService : BackgroundService
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IHubContext<ChatHub> _hubContext;

        public BotResponseBackgroundService(IRabbitMqService rabbitMqService, IHubContext<ChatHub> hubContext)
        {
            _rabbitMqService = rabbitMqService;
            _hubContext = hubContext;
        }

        private async Task SendChatMessageAsync(ChatMessage message, CancellationToken ct)
        {
            await _hubContext.Clients.All.SendAsync(HubConstants.ReceiveMessage, BotConstants.Name, message.Message, BotConstants.Id);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            await _rabbitMqService.Consume<ChatMessage>(QueueNames.Chat, SendChatMessageAsync);
        }
    }
