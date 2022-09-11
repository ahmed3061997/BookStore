using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Features.Books.Queries
{
    public class GetBooksHandler : IRequestHandler<GetBooks, IResultResponse<IEnumerable<Book>>>
    {
        private readonly IQueryRepository<Book> repository;

        public GetBooksHandler(IQueryRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<IResultResponse<IEnumerable<Book>>> Handle(GetBooks request, CancellationToken cancellationToken)
        {
            var validator = new GetBooksValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return new ResultResponse<IEnumerable<Book>>() { Result = true, Errors = result.Errors.Select(x => x.ErrorMessage) };

            }

            var skip = request.PageSize * (request.CurrentPage - 1);
            var list = await repository.Skip(skip).Take(request.PageSize).ToListAsync();

            return new ResultResponse<IEnumerable<Book>>() { Result = true, Errors = null, Value = list };
        }
    }
}
