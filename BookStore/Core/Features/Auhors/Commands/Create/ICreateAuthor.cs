using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Features.Auhors.Commands
{
    public interface ICreateAuthor : IRequest<IResultResponse<Guid?>>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
