using GChatBot.Data.Entities;
using GChatBot.Data.Maps;
using GChatBot.Data.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GChatBot.Data;

public class GChatBotDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public DbSet<ChatMessage> ChatMessages { get; set; }

    public GChatBotDbContext(DbContextOptions<GChatBotDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .AddIdentityMap()
            .AddChatBotSeed()
            .ApplyConfigurationsFromAssembly(typeof(GChatBotDbContext).Assembly);
    }
}