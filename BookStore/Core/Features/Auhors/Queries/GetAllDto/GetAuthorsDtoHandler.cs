using BookStore.Core.Features.Auhors.Dto;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Auhors.Queries.GetAllDto
{
    public class GetAuthorsDtoHandler : IRequestHandler<GetAuthorsDto, IResultResponse<IEnumerable<AuthorDto>>>
    {
        private readonly IAuthorService service;

        public GetAuthorsDtoHandler(IAuthorService service)
        {
            this.service = service;
        }

        public async Task<IResultResponse<IEnumerable<AuthorDto>>> Handle(GetAuthorsDto request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await service.GetAllDto();
                return new ResultResponse<IEnumerable<AuthorDto>>() { Result = true, Errors = null, Value = list };
            }
            catch (Exception ex)
            {
                return new ResultResponse<IEnumerable<AuthorDto>>() { Result = false, Errors = new[] { ex.Message } };
            }
        }
    }
}
