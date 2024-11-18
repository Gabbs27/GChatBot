namespace GChatBot.Data.Entities;

public class ChatMessage
{
    public int Id { get; set; }
    public required string Message { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}