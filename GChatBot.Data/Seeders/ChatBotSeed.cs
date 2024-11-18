using GChatBot.Data.Constants;
using GChatBot.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GChatBot.Data.Seeders;

public static class ChatBotSeed
{
    public static ModelBuilder AddChatBotSeed(this ModelBuilder builder)
    {
        var botUser = new User
        {
            Id = BotConstants.Id,
            Email = BotConstants.Mail,
            EmailConfirmed = true,
            UserName = BotConstants.Name,
            FirstName = "Stock",
            LastName = "Bot"
        };

        var ph = new PasswordHasher<User>();
        botUser.PasswordHash = ph.HashPassword(botUser, "chat-^bot");

        builder.Entity<User>().HasData(botUser);

        return builder;
    }
}   