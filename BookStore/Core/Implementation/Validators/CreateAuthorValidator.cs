using BookStore.Core.Interfaces.Commands;
using FluentValidation;

namespace BookStore.Core.Implementation.Validators
{
    public class CreateAuthorValidator : AbstractValidator<ICreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(255);
            RuleFor(x => x.Category).NotNull().MaximumLength(255);
            RuleFor(x => x.Image).NotNull();
        }
    }
}
