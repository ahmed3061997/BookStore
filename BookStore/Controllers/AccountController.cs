using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Constants;
using BookStore.Core.Generic.Responses;
using BookStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IResponse> Register(UserRegistrationModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new Response() { Result = false, Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage) };
            }
            var user = mapper.Map<User>(userModel);
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return new Response() { Result = false, Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage) };
            }
            await userManager.AddToRoleAsync(user, Roles.Visitor);
            return new Response() { Result = true };
        }

        [HttpPost("login")]
        public async Task<IResponse> Login(UserLoginModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new Response() { Result = false, Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage) };
            }
            var result = await signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                return new Response() { Result = true };
            }
            else
            {
                return new Response() { Result = false, Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage) };
            }
        }

        [HttpPost("logout")]
        public async Task<IResponse> Logout()
        {
            await signInManager.SignOutAsync();
            return new Response() { Result = true };
        }
    }
}
