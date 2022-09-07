using BookStore.Core.Domain;
using BookStore.Core.Interfaces.Commands;
using BookStore.Core.Interfaces.Repository;
using MediatR;

namespace BookStore.Core.Implementations.Handlers
{
    public class CreateAuthorHandler : IRequestHandler<ICreateAuthor>
    {
        private readonly IRepository<Author> repository;

        public CreateAuthorHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(ICreateAuthor request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.Author == null)
                throw new ArgumentNullException("request.Author");

            repository.Create(request.Author);
            await repository.SaveChanges();
            return Unit.Value;
        }
    }
}
