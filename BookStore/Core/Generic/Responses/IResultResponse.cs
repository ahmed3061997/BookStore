namespace BookStore.Core.Generic.Responses
{
    public interface IResultResponse<T> : IResponse
    {
        public T? Value { get; set; }
    }
}
