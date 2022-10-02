using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using BookStore.Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Features.Auhors.Queries
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthors, IResultResponse<IEnumerable<Author>>>
    {
        private readonly IAuthorService service;

        public GetAuthorsHandler(IAuthorService service)
        {
            this.service = service;
        }

        public async Task<IResultResponse<IEnumerable<Author>>> Handle(GetAuthors request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await service.GetPage(request.CurrentPage, request.PageSize);
                return new ResultResponse<IEnumerable<Author>>() { Result = true, Errors = null, Value = list };
            }
            catch (Exception ex)
            {
                return new ResultResponse<IEnumerable<Author>>() { Result = false, Errors = new[] { ex.Message } };
            }
        }
    }
}
