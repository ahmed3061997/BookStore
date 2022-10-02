using BookStore.Core.Domain;
using BookStore.Core.Features.Books.Commands;
using BookStore.Core.Features.Books.Queries;
using BookStore.Core.Generic.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IResultResponse<IEnumerable<Book>>> GetPage([FromQuery] GetBooks request)
        {
            var response = await mediator.Send(request);
            return response;
        }

        [HttpPost("create")]
        public async Task<IResultResponse<Guid?>> Create([FromForm] CreateBook request)
        {
            var response = await mediator.Send(request);
            return response;
        }
    }
}
