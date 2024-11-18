using GChatBot.Data;
using GChatBot.Data.Entities;
using GChatBot.Services.ChatServices;
using GChatBot.Services.RabbitMqServices;
using GChatBot.Services.UserServices;
using GChatBot.WebApi.HostServices;
using GChatBot.WebApi.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowAnyHeader();
    });
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        builder
            .WithOrigins("https://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContextFactory<GChatBotDbContext>(options => options.UseSqlServer(connectionString));

builder.Services
    .AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    })
    .AddEntityFrameworkStores<GChatBotDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IChatMessageService, ChatMessageService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBotCommandService, BotCommandService>();
builder.Services.AddTransient<IRabbitMqService, RabbitMqService>();

builder.Services.AddHostedService<BotResponseBackgroundService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chathub");


app.Run();