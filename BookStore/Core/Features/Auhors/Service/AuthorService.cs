using BookStore.Core.Domain;
using BookStore.Core.Generic.Dto;
using BookStore.Core.Generic.Exceptions;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BookStore.Core.Features.Auhors.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IQueryRepository<Author> repository;

        public AuthorService(IQueryRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task Create(Author author)
        {
            var validator = new AuthorValidator();
            var result = validator.Validate(author);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            repository.Create(author);
            await repository.SaveChanges();
        }

        public async Task<bool> Delete(Guid id)
        {
            repository.Delete(x => x.Id == id);
            return await repository.SaveChanges() > 0;
        }

        public async Task<IEnumerable<ObjectDto>> GetAllDto()
        {
            return await repository.Select(x => new ObjectDto(x.Id, x.Name)).ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetPage(int page, int size)
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

        public async Task Update(Author author)
        {
            var validator = new AuthorValidator(true);
            var result = validator.Validate(author);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            repository.Update(author);
            await repository.SaveChanges();
        }
    }
}
