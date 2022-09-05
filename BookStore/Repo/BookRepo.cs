namespace BookStore.Repo
{
    public class BookRepo : DbRepo<Book>
    {
        public BookRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
