using BookStore.Core.Domain;

namespace BookStore.Core.Interfaces.Queries
{
    public interface IGetAuthors : IPaginationQuery<Author>
    {
    }
}
