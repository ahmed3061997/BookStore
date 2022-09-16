using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Generic.Exceptions;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Services;
using MediatR;

namespace BookStore.Core.Features.Auhors.Commands.Update
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthor, IResponse>
    {
        private readonly IFileManager fileManager;
        private readonly IAuthorService service;
        private readonly IMapper mapper;

        public UpdateAuthorHandler(IAuthorService service, IMapper mapper, IFileManager fileManager)
        {
            this.service = service;
            this.mapper = mapper;
            this.fileManager = fileManager;
        }

        public async Task<IResponse> Handle(UpdateAuthor request, CancellationToken cancellationToken)
        {
            try
            {
                var author = mapper.Map<Author>(request);
                author.Image = fileManager.SaveFile(request.ImageFile);

                await service.Update(author);
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
