using BookStore.Core.Features.Auhors.Dto;
using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Auhors.Queries.GetAllDto
{
    public interface IGetAuthorsDto : IRequest<IResultResponse<IEnumerable<AuthorDto>>>
    {
    }
}
