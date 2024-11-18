using GChatBot.Worker;
using Microsoft.EntityFrameworkCore;
using GChatBot.Data;
using GChatBot.Services.RabbitMqServices;
using GChatBot.Worker.HostServices;
using GChatBot.Services.ChatServices;
using GChatBot.Services.UserServices;
using GChatBot.Data.Entities;
using Microsoft.AspNetCore.Identity;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient();


        var connectionString = hostContext.Configuration.GetConnectionString("Default");
        services.AddDbContextFactory<GChatBotDbContext>(options => options.UseSqlServer(connectionString));

        services.Configure<StockOptions>(hostContext.Configuration.GetRequiredSection(StockOptions.STOCK_API_OPTIONS));

        services.AddTransient<IStockService, StockService>();
        services.AddTransient<IUserService, UserService>();
        services.AddSingleton<IRabbitMqService, RabbitMqService>();


        services.AddHostedService<BotRequestBackgroundService>();
    })
    .Build();

await host.StartAsync();
await host.WaitForShutdownAsync();