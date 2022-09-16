using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Auhors.Commands
{
    public interface IUpdateAuthor : IRequest<IResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
