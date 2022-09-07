using BookStore.Core.Interfaces.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Interfaces.Commands
{
    public interface ICreateBook : IRequest<IResultResponse<Guid?>>
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
        public string CoverImg { get; set; }
    }
}
