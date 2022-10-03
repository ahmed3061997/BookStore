using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Constants;
using BookStore.Core.Generic.Dto;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Services.Authentication;
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
        private readonly IUserService userService;

        public AccountController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IResultResponse<JwtToken>> Register(UserRegistrationModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new ResultResponse<JwtToken>() { Result = false, Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage) };
            }
            var user = mapper.Map<User>(userModel);
            var result = await userService.CreateUser(user, userModel.Password);
            return new ResultResponse<JwtToken>() { Result = result.Succeeded, Errors = result.Errors, Value = result.Token };
        }

        [HttpPost("login")]
        public async Task<IResultResponse<JwtToken>> Login(UserLoginModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new ResultResponse<JwtToken>() { Result = false, Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage) };
            }
            var result = await userService.Login(userModel.Email, userModel.Password);
            return new ResultResponse<JwtToken>() { Result = result.Succeeded, Errors = result.Errors, Value = result.Token };
        }

        [HttpPost("logout")]
        public async Task<IResponse> Logout()
        {
            await userService.Logout();
            return new Response() { Result = true };
        }
    }
}
