namespace GChatBot.Data.Records;

public record CommandInformation(string Command, string Parameter, string? Error = null);