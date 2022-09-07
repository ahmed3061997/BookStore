using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Interfaces.Commands;

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
