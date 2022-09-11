using BookStore.Core.Domain;

namespace BookStore.Core.Repositiory
{
    public class BookRepo : DbRepo<Book>
    {
        public BookRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
