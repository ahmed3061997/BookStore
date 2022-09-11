using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Features.Auhors.Queries
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthors, IResultResponse<IEnumerable<Author>>>
    {
        private readonly IQueryRepository<Author> repository;

        public GetAuthorsHandler(IQueryRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task<IResultResponse<IEnumerable<Author>>> Handle(GetAuthors request, CancellationToken cancellationToken)
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
