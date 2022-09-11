using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using BookStore.Core.Services;
using MediatR;

namespace BookStore.Core.Features.Books.Commands
{
    public class CreateBookHandler : IRequestHandler<CreateBook, IResultResponse<Guid?>>
    {
        private readonly IRepository<Book> repository;
        private readonly IFileManager fileManager;
        private readonly IMapper mapper;

        public CreateBookHandler(IRepository<Book> repository, IMapper mapper, IFileManager fileManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.fileManager = fileManager;
        }

        public async Task<IResultResponse<Guid?>> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return new ResultResponse<Guid?>() { Result = false, Errors = result.Errors.Select(x => x.ErrorMessage) };
            }

            var book = mapper.Map<Book>(request);
            book.Id = Guid.NewGuid();
            book.CoverImg = fileManager.SaveFile(request.CoverImgFile);

            repository.Create(book);
            await repository.SaveChanges();

            return new ResultResponse<Guid?>() { Result = true, Errors = null, Value = book.Id };
        }
    }
}
