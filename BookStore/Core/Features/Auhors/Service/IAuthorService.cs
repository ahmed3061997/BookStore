using BookStore.Core.Domain;
using BookStore.Core.Generic.Dto;

namespace BookStore.Core.Features.Auhors.Service
{
    public interface IAuthorService
    {
        Task Create(Author author);
        Task Update(Author author);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Author>> GetPage(int page, int size);
        Task<IEnumerable<ObjectDto>> GetAllDto();
    }
}
