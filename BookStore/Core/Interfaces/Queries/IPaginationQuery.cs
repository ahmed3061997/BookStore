using BookStore.Core.Interfaces.Responses;
using MediatR;

namespace BookStore.Core.Interfaces.Queries
{
    public interface IPaginationQuery<T> : IRequest<IResultResponse<IEnumerable<T>>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
