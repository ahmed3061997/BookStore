using FluentValidation.Results;

namespace BookStore.Core.Generic.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationFailure> errors)
            : base("One or more validation errors found")
        {
            Errors = errors;
        }

        public IEnumerable<ValidationFailure> Errors { get; }
    }
}
