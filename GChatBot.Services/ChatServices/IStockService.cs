namespace GChatBot.Services.ChatServices;

public interface IStockService
{
    Task<string> GetStockMessage(string baseUrl, string parameter, CancellationToken ct);
}