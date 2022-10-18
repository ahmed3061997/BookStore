using BookStore.Core.Domain;

namespace BookStore.Core.Repository
{
    public class BookRepo : DbRepo<Book>
    {
        public BookRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
