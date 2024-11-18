using GChatBot.Data.Entities;
using GChatBot.Services.DTOs;

namespace GChatBot.Services.UserServices;

public interface IUserService
{
    Task<SignInDTOResponse> SignIn(SignInDTO user);
    Task<SignUpDTOResponse> SignUp(SignUpDTO user);
    Task<User?> GetUserAsync(int id);
    Task<User?> GetUserAsync(string userName);
}