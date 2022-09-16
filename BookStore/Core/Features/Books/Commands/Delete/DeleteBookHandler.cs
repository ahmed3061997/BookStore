using BookStore.Core.Features.Auhors.Commands.Delete;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Features.Books.Service;
using BookStore.Core.Generic.Exceptions;
using BookStore.Core.Generic.Responses;
using MediatR;

namespace BookStore.Core.Features.Books.Commands.Delete
{
    public class DeleteBookHandler : IRequestHandler<DeleteBook, IResponse>
    {
        private readonly IBookService service;

        public DeleteBookHandler(IBookService service)
        {
            this.service = service;
        }

        public async Task<IResponse> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.Delete(request.Id);
                return new Response() { Result = result, Errors = null };
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
