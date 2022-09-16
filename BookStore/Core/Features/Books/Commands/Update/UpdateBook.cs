namespace BookStore.Core.Features.Books.Commands.Update
{
    public class UpdateBook : IUpdateBook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImgFile { get; set; }
    }
}
