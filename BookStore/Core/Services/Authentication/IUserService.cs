using BookStore.Core.Domain;
using BookStore.Core.Generic.Dto;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Core.Services.Authentication
{
    public interface IUserService
    {
        Task<AuthResult> CreateUser(User user, string password);
        Task<AuthResult> Login(string username, string password);
        Task<AuthResult> RefreshToken(string token);
        Task Logout();
    }
}
