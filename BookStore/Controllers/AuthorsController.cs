using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Commands;
using BookStore.Core.Features.Auhors.Dto;
using BookStore.Core.Features.Auhors.Queries;
using BookStore.Core.Features.Auhors.Queries.GetAllDto;
using BookStore.Core.Generic.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IResultResponse<IEnumerable<Author>>> GetPage([FromQuery] GetAuthors request)
        {
            var response = await mediator.Send(request);
            return response;
        }

        [HttpGet("get_all")]
        public async Task<IResultResponse<IEnumerable<AuthorDto>>> GetAllDto()
        {
            var response = await mediator.Send(new GetAuthorsDto());
            return response;
        }

        [HttpPost("create")]
        public async Task<IResultResponse<Guid?>> Create([FromForm] CreateAuthor request)
        {
            var response = await mediator.Send(request);
            return response;
        }
    }
}
