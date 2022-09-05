namespace BookStore.Repo
{
    public class AuthorRepo : DbRepo<Author>
    {
        public AuthorRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
