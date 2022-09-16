namespace BookStore.Core.Features.Auhors.Commands.Update
{
    public class UpdateAuthor : IUpdateAuthor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
