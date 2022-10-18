using BookStore.Core.Domain;

namespace BookStore.Core.Repository
{
    public class RefreshTokenRepo : DbRepo<RefreshToken>
    {
        public RefreshTokenRepo(BookStoreDbContext context) : base(context)
        {
        }
    }
}
