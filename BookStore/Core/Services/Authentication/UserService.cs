using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Constants;
using BookStore.Core.Generic.Dto;
using BookStore.Core.Generic.Responses;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Core.Services.Authentication
{
    public class UserService : IUserService
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly ITokenService tokenService;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task<AuthResult> CreateUser(User user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Visitor);
                var token = await tokenService.GenerateToken(user);
                return new AuthResult()
                {
                    Succeeded = true,
                    Token = token
                };
            }
            else
            {
                return new AuthResult()
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(x => x.Description)
                };
            }
        }

        public async Task<AuthResult> Login(string username, string password)
        {
            var res = await signInManager.PasswordSignInAsync(username, password, false, false);
            var result = new AuthResult()
            {
                Succeeded = res.Succeeded,
            };
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(username);
                result.Token = await tokenService.GenerateToken(user);
            }
            else
            {
                var errors = new List<string>();
                if (res.IsNotAllowed)
                {
                    errors.Add("Your account is blocked");
                }
                else if (res.IsLockedOut)
                {
                    errors.Add("Your account is locked");
                }
                else
                {
                    errors.Add("Invalid Email or Password");
                }
                result.Errors = errors;
            }
            return result;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
