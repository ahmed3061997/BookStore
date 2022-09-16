using BookStore.Core.Domain;
using FluentValidation;

namespace BookStore.Core.Features.Auhors.Service
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator(bool requireId = false)
        {
            if (requireId)
            {
                RuleFor(x => x.Id).NotNull();
            }
            RuleFor(x => x.Name).NotNull().MaximumLength(255);
            RuleFor(x => x.Category).NotNull().MaximumLength(255);
            RuleFor(x => x.Image).NotNull();
        }
    }
}
