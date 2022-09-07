using BookStore.Core.Interfaces.Queries;
using FluentValidation;

namespace BookStore.Core.Implementation.Validators
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
