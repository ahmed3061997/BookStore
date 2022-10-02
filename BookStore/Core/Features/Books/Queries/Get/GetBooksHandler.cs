using BookStore.Core.Domain;
using BookStore.Core.Features.Books.Service;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Features.Books.Queries
{
    public class GetBooksHandler : IRequestHandler<GetBooks, IResultResponse<IEnumerable<Book>>>
    {
        private readonly IBookService service;

        public GetBooksHandler(IBookService service)
        {
            this.service = service;
        }

        public async Task<IResultResponse<IEnumerable<Book>>> Handle(GetBooks request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await service.GetPage(request.CurrentPage, request.PageSize);
                return new ResultResponse<IEnumerable<Book>>() { Result = true, Errors = null, Value = list };
            }
            catch (Exception ex)
            {
                return new ResultResponse<IEnumerable<Book>>() { Result = false, Errors = new[] { ex.Message } };
            }
        }
    }
}
