using GChatBot.Data;
using Microsoft.EntityFrameworkCore;

namespace GChatBot.Services;

public abstract class BaseDbServices<T>
{
    protected readonly GChatBotDbContext _dbContext;

    public BaseDbServices(IDbContextFactory<GChatBotDbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }
}