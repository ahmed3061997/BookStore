using BookStore.Core.Domain;
using BookStore.Core.Generic.Exceptions;
using BookStore.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Features.Books.Service
{
    public class BookService : IBookService
    {
        private readonly IQueryRepository<Book> repository;

        public BookService(IQueryRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task Create(Book book)
        {
            var validator = new BookValidator();
            var result = validator.Validate(book);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            repository.Create(book);
            await repository.SaveChanges();
        }

        public async Task<bool> Delete(Guid id)
        {
            repository.Delete(x => x.Id == id);
            return await repository.SaveChanges() > 0;
        }

        public async Task<IEnumerable<Book>> GetPage(int page, int size)
        {
            if (page < 0)
            {
                throw new ArgumentException("Invalid value", "page");
            }
            if (size <= 0)
            {
                throw new ArgumentException("Invalid value", "size");
            }

            return await repository.Skip(page * size).Take(size).ToListAsync();
        }

        public async Task Update(Book book)
        {
            var validator = new BookValidator(true);
            var result = validator.Validate(book);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            repository.Update(book);
            await repository.SaveChanges();
        }
    }
}
