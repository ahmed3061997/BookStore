using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Generic.Exceptions;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Core.Features.Auhors.Commands.Delete
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthor, IResponse>
    {
        private readonly IAuthorService service;

        public DeleteAuthorHandler(IAuthorService service)
        {
            this.service = service;
        }

        public async Task<IResponse> Handle(DeleteAuthor request, CancellationToken cancellationToken)
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
