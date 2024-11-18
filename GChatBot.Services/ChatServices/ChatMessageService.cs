using GChatBot.Data;
using GChatBot.Data.Entities;
using GChatBot.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GChatBot.Services.ChatServices;

    public class ChatMessageService : BaseDbServices<ChatMessage>, IChatMessageService
    {
        public ChatMessageService(IDbContextFactory<GChatBotDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<ChatMessage> AddChatMessage(string message, int userId)
        {
            var entry = _dbContext.ChatMessages.Add(new ChatMessage
            {
                Message = message,
                UserId = userId,
                CreatedAt = DateTime.Now
            });

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public IEnumerable<ChatMessageDTO> GetRecentChatMessages()
        {
            return _dbContext.ChatMessages
                .OrderByDescending(m => m.CreatedAt)
                .Take(50)
                .OrderBy(m => m.CreatedAt)
                .Select(m => new ChatMessageDTO
                {
                    Message = m.Message,
                    UserName = m.User.UserName ?? string.Empty
                });
        }
    }
