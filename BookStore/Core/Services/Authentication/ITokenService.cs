using BookStore.Core.Domain;
using BookStore.Core.Generic.Dto;

namespace BookStore.Core.Services.Authentication
{
    public interface ITokenService
    {
        Task<JwtToken> GenerateToken(User user);
        //Task<JwtToken> RefreshToken(User user, string refreshToken);
    }
}
