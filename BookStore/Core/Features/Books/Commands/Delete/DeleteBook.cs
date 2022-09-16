namespace BookStore.Core.Features.Books.Commands.Delete
{
    public class DeleteBook : IDeleteBook
    {
        public Guid Id { get; set; }
    }
}
