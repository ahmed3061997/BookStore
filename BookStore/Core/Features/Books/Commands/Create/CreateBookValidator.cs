using FluentValidation;

namespace BookStore.Core.Features.Books.Commands
{
    public class CreateBookValidator : AbstractValidator<ICreateBook>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(255);
            RuleFor(x => x.AuthorId).NotNull();
            RuleFor(x => x.CoverImgFile).NotNull();
            RuleFor(x => x.Description).NotNull().MaximumLength(255);
        }
    }
}
