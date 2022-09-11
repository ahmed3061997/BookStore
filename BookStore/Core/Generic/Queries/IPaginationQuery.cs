using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Generic.Queries
{
    public interface IPaginationQuery<T> : IRequest<IResultResponse<IEnumerable<T>>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
