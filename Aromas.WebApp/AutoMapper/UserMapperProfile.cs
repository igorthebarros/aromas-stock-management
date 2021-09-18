using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;

namespace Aromas.MVC.AutoMapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}