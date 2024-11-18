using Microsoft.AspNetCore.Identity;

namespace GChatBot.Data.Entities;

public class User : IdentityUser<int>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}