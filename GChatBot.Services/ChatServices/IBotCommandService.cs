using GChatBot.Data.Records;

namespace GChatBot.Services.ChatServices;

public interface IBotCommandService
{
    string? ValidateCommand(string text);
    CommandInformation GetCommandInformation(string text);
    bool IsCommand(string text);
}