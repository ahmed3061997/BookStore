using BookStore.Core.Domain;
using BookStore.Core.Interfaces.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Interfaces.Commands
{
    public interface ICreateAuthor : IRequest<IResultResponse<Guid?>>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
