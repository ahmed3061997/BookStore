using System.Runtime.Serialization;

namespace BookStore.Core.Generic.Responses
{
    public interface IResponse
    {
        public bool Result { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
