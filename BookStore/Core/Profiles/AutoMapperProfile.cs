using AutoMapper;
using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Commands;
using BookStore.Core.Features.Books.Commands;
using BookStore.Models;

namespace BookStore.Core.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ICreateAuthor, Author>();
            CreateMap<IUpdateAuthor, Author>();
            CreateMap<ICreateBook, Book>();
            CreateMap<IUpdateBook, Book>();
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
