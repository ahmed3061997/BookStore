using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Books.Commands
{
    public interface IUpdateBook : IRequest<IResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImgFile { get; set; }
    }
}
