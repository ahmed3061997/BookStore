using BookStore.Core.Domain;

namespace BookStore.Core.Implementations.Repositiory
{
    public class AuthorRepo : DbRepo<Author>
    {
        public AuthorRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
