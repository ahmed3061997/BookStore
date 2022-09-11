namespace BookStore.Core.Features.Auhors.Commands
{
    public class CreateAuthor : ICreateAuthor
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
