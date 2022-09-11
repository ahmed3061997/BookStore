using BookStore.Core.Domain;

namespace BookStore.Core.Repositiory
{
    public class AuthorRepo : DbRepo<Author>
    {
        public AuthorRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
