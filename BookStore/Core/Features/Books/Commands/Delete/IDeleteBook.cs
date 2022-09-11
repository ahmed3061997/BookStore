using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Books.Commands
{
    public interface IDeleteBook : IRequest<IResponse>
    {
        public Guid Id { get; set; }
    }
}
