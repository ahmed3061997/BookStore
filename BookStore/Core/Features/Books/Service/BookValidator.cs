using BookStore.Core.Domain;
using FluentValidation;

namespace BookStore.Core.Features.Books.Service
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator(bool requireId = false)
        {
            if (requireId)
            {
                RuleFor(x => x.Id).NotNull();
            }
            RuleFor(x => x.Name).NotNull().MaximumLength(255);
            RuleFor(x => x.AuthorId).NotNull();
            RuleFor(x => x.CoverImg).NotNull();
            RuleFor(x => x.Description).NotNull().MaximumLength(255);
        }
    }
}
