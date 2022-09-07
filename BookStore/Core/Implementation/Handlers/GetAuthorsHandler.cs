using BookStore.Core.Domain;
using BookStore.Core.Implementation.Responses;
using BookStore.Core.Implementation.Validators;
using BookStore.Core.Interfaces.Queries;
using BookStore.Core.Interfaces.Repository;
using BookStore.Core.Interfaces.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Implementation.Handlers
{
    public class GetAuthorsHandler : IRequestHandler<IGetAuthors, IResultResponse<IEnumerable<Author>>>
    {
        private readonly IQueryRepository<Author> repository;

        public GetAuthorsHandler(IQueryRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task<IResultResponse<IEnumerable<Author>>> Handle(IGetAuthors request, CancellationToken cancellationToken)
        {
            var validator = new GetAuthorsValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return new ResultResponse<IEnumerable<Author>>() { Result = true, Errors = result.Errors.Select(x => x.ErrorMessage) };

            }

            var skip = request.PageSize * (request.CurrentPage - 1);
            var list = await repository.Skip(skip).Take(request.PageSize).ToListAsync();

            return new ResultResponse<IEnumerable<Author>>() { Result = true, Errors = null, Value = list };
        }
    }
}
