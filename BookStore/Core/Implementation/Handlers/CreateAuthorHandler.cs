﻿using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Implementation.Responses;
using BookStore.Core.Implementation.Validators;
using BookStore.Core.Interfaces.Commands;
using BookStore.Core.Interfaces.Repository;
using BookStore.Core.Interfaces.Responses;
using MediatR;

namespace BookStore.Core.Implementations.Handlers
{
    public class CreateAuthorHandler : IRequestHandler<ICreateAuthor, IResultResponse<Guid?>>
    {
        private readonly IRepository<Author> repository;
        private readonly IMapper mapper;

        public CreateAuthorHandler(IRepository<Author> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IResultResponse<Guid?>> Handle(ICreateAuthor request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuthorValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return new ResultResponse<Guid?>() { Result = false, Errors = result.Errors.Select(x => x.ErrorMessage) };
            }

            var author = mapper.Map<Author>(request);
            author.Id = Guid.NewGuid();

            repository.Create(author);
            await repository.SaveChanges();

            return new ResultResponse<Guid?>() { Result = true, Errors = null, Value = author.Id };
        }
    }
}
