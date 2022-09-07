using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Implementation.Responses;
using BookStore.Core.Implementation.Validators;
using BookStore.Core.Interfaces.Commands;
using BookStore.Core.Interfaces.Repository;
using BookStore.Core.Interfaces.Responses;
using MediatR;

namespace BookStore.Core.Implementation.Handlers
{
    public class CreateBookHandler : IRequestHandler<ICreateBook, IResultResponse<Guid?>>
    {
        private readonly IRepository<Book> repository;
        private readonly IMapper mapper;

        public CreateBookHandler(IRepository<Book> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IResultResponse<Guid?>> Handle(ICreateBook request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return new ResultResponse<Guid?>() { Result = false, Errors = result.Errors.Select(x => x.ErrorMessage) };
            }

            var book = mapper.Map<Book>(request);
            book.Id = Guid.NewGuid();

            repository.Create(book);
            await repository.SaveChanges();

            return new ResultResponse<Guid?>() { Result = true, Errors = null, Value = book.Id };
        }
    }
}
