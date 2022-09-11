using FluentValidation;

namespace BookStore.Core.Features.Auhors.Commands
{
    public class CreateAuthorValidator : AbstractValidator<ICreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(255);
            RuleFor(x => x.Category).NotNull().MaximumLength(255);
            RuleFor(x => x.ImageFile).NotNull();
        }
    }
}
