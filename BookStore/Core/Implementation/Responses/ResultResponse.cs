using BookStore.Core.Interfaces.Responses;

namespace BookStore.Core.Implementation.Responses
{
    public class ResultResponse<T> : Response, IResultResponse<T>
    {
        public T? Value { get; set; }
    }
}
