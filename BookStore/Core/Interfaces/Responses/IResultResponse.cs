namespace BookStore.Core.Interfaces.Responses
{
    public interface IResultResponse<T> : IResponse
    {
        public T? Value { get; set; }
    }
}
