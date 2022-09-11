using FluentValidation;

namespace BookStore.Core.Features.Auhors.Queries
{
    public class GetAuthorsValidator : AbstractValidator<IGetAuthors>
    {
        public GetAuthorsValidator()
        {
            RuleFor(x => x.CurrentPage).GreaterThan(-1);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
