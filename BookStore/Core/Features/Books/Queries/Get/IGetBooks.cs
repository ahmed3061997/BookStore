using BookStore.Core.Domain;
using BookStore.Core.Generic.Queries;

namespace BookStore.Core.Features.Books.Queries
{
    public interface IGetBooks : IPaginationQuery<Book>
    {
    }
}
