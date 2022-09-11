namespace BookStore.Core.Features.Books.Queries
{
    public class GetBooks : IGetBooks
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
