using BookStore.Core.Domain;

namespace BookStore.Core.Repository
{
    public class AuthorRepo : DbRepo<Author>
    {
        public AuthorRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
