using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Auhors.Commands
{
    public interface IEditAuthor : IRequest<IResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
