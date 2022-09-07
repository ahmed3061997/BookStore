using BookStore.Core.Domain;
using MediatR;

namespace BookStore.Core.Interfaces.Commands
{
    public interface ICreateAuthor : IRequest
    {
        public Author Author { get; set; }
    }
}
