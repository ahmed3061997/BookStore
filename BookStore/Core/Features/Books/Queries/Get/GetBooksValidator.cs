using FluentValidation;

namespace BookStore.Core.Features.Books.Queries
{
    public class GetBooksValidator : AbstractValidator<IGetBooks>
    {
        public GetBooksValidator()
        {
            RuleFor(x => x.CurrentPage).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
