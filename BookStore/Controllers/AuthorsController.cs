using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Commands;
using BookStore.Core.Features.Auhors.Queries;
using BookStore.Core.Generic.Responses;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookStore.Controllers
{
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

        [HttpPost("create")]
        public async Task<IResultResponse<Guid?>> Create([FromForm] ICreateAuthor request)
        {
            var response = await mediator.Send(request);
            return response;
        }
    }
}
