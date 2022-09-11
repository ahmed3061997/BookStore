namespace BookStore.Core.Features.Auhors.Queries
{
    public class GetAuthors : IGetAuthors
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
