using BookStore.Core.Interfaces.Commands;
using FluentValidation;

namespace BookStore.Core.Implementation.Validators
{
    public class CreateBookValidator : AbstractValidator<ICreateBook>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(255);
            RuleFor(x => x.AuthorId).NotNull();
            RuleFor(x => x.CoverImg).NotNull();
            RuleFor(x => x.Description).NotNull().MaximumLength(255);
        }
    }
}
