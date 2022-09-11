using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Generic.Responses;
using BookStore.Core.Repository;
using BookStore.Core.Services;
using MediatR;

namespace BookStore.Core.Features.Auhors.Commands
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthor, IResultResponse<Guid?>>
    {
        private readonly IRepository<Author> repository;
        private readonly IFileManager fileManager;
        private readonly IMapper mapper;

        public CreateAuthorHandler(IRepository<Author> repository, IMapper mapper, IFileManager fileManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.fileManager = fileManager;
        }

        public async Task<IResultResponse<Guid?>> Handle(CreateAuthor request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuthorValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return new ResultResponse<Guid?>() { Result = false, Errors = result.Errors.Select(x => x.ErrorMessage) };
            }

            var author = mapper.Map<Author>(request);
            author.Id = Guid.NewGuid();
            author.Image = fileManager.SaveFile(request.ImageFile);

            repository.Create(author);
            await repository.SaveChanges();

            return new ResultResponse<Guid?>() { Result = true, Errors = null, Value = author.Id };
        }
    }
}
