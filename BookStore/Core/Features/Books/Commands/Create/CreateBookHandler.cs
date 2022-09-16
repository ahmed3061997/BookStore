using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using MediatR;
using BookStore.Core.Services;
using BookStore.Core.Features.Books.Service;
using BookStore.Core.Generic.Exceptions;

namespace BookStore.Core.Features.Books.Commands
{
    public class CreateBookHandler : IRequestHandler<CreateBook, IResultResponse<Guid?>>
    {
        private readonly IFileManager fileManager;
        private readonly IBookService service;
        private readonly IMapper mapper;

        public CreateBookHandler(IBookService service, IMapper mapper, IFileManager fileManager)
        {
            this.service = service;
            this.mapper = mapper;
            this.fileManager = fileManager;
        }

        public async Task<IResultResponse<Guid?>> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            try
            {
                var book = mapper.Map<Book>(request);
                book.Id = Guid.NewGuid();
                book.CoverImg = fileManager.SaveFile(request.CoverImgFile);

                await service.Create(book);
                return new ResultResponse<Guid?>() { Result = true, Errors = null, Value = book.Id };
            }
            catch (ValidationException ex)
            {
                return new ResultResponse<Guid?>() { Result = false, Errors = ex.Errors.Select(x => x.ErrorMessage) };
            }
            catch (Exception ex)
            {
                return new ResultResponse<Guid?>() { Result = false, Errors = new[] { ex.Message } };
            }
        }
    }
}
