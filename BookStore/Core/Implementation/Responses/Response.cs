using BookStore.Core.Interfaces.Responses;

namespace BookStore.Core.Implementation.Responses
{
    public class Response : IResponse
    {
        public bool Result { get; set; }
        public IEnumerable<string>? Errors { get; set ; }
    }
}
