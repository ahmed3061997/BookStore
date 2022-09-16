using BookStore.Core.Domain;
using BookStore.Core.Generic.Dto;

namespace BookStore.Core.Features.Books.Service
{
    public interface IBookService
    {
        Task Create(Book Book);
        Task Update(Book Book);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Book>> GetPage(int page, int size);
    }
}
