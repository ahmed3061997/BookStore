using BookStore.Core.Domain;

namespace BookStore.Core.Implementations.Repositiory
{
    public class BookRepo : DbRepo<Book>
    {
        public BookRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
