using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Auhors.Commands
{
    public interface IDeleteAuthor : IRequest<IResponse>
    {
        public Guid Id { get; set; }
    }
}
