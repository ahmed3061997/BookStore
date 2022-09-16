using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using MediatR;
using BookStore.Core.Services;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Generic.Exceptions;

namespace BookStore.Core.Features.Auhors.Commands
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthor, IResultResponse<Guid?>>
    {
        private readonly IFileManager fileManager;
        private readonly IAuthorService service;
        private readonly IMapper mapper;

        public CreateAuthorHandler(IAuthorService service, IMapper mapper, IFileManager fileManager)
        {
            this.service = service;
            this.mapper = mapper;
            this.fileManager = fileManager;
        }

        public async Task<IResultResponse<Guid?>> Handle(CreateAuthor request, CancellationToken cancellationToken)
        {
            try
            {
                var author = mapper.Map<Author>(request);
                author.Id = Guid.NewGuid();
                author.Image = fileManager.SaveFile(request.ImageFile);

                await service.Create(author);
                return new ResultResponse<Guid?>() { Result = true, Errors = null, Value = author.Id };
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
