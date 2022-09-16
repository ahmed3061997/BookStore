using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Commands.Update;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Features.Books.Service;
using BookStore.Core.Generic.Exceptions;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Services;
using MediatR;

namespace BookStore.Core.Features.Books.Commands.Update
{
    public class UpdateBookHandler : IRequestHandler<UpdateBook, IResponse>
    {
        private readonly IFileManager fileManager;
        private readonly IBookService service;
        private readonly IMapper mapper;

        public UpdateBookHandler(IBookService service, IMapper mapper, IFileManager fileManager)
        {
            this.service = service;
            this.mapper = mapper;
            this.fileManager = fileManager;
        }

        public async Task<IResponse> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            try
            {
                var book = mapper.Map<Book>(request);
                book.CoverImg = fileManager.SaveFile(request.CoverImgFile);

                await service.Update(book);
                return new Response() { Result = true, Errors = null };
            }
            catch (ValidationException ex)
            {
                return new Response() { Result = false, Errors = ex.Errors.Select(x => x.ErrorMessage) };
            }
            catch (Exception ex)
            {
                return new Response() { Result = false, Errors = new[] { ex.Message } };
            }
        }
    }
}
