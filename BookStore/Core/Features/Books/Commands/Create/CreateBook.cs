namespace BookStore.Core.Features.Books.Commands
{
    public class CreateBook : ICreateBook
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImgFile { get; set; }
    }
}
