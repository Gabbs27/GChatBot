using GChatBot.Data.Entities;
using GChatBot.Services.DTOs;

namespace GChatBot.Services.ChatServices;

public interface IChatMessageService
{
    Task<ChatMessage> AddChatMessage(string message, int userId);
    IEnumerable<ChatMessageDTO> GetRecentChatMessages();
}