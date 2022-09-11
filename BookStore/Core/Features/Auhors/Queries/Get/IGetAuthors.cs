using BookStore.Core.Domain;
using BookStore.Core.Generic.Queries;

namespace BookStore.Core.Features.Auhors.Queries
{
    public interface IGetAuthors : IPaginationQuery<Author>
    {
    }
}
