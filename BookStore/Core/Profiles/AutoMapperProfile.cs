using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Commands;
using BookStore.Core.Features.Books.Commands;

namespace BookStore.Core.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ICreateAuthor, Author>();
            CreateMap<ICreateBook, Book>();
        }
    }
}
