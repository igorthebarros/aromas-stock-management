using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;

namespace Aromas.MVC.AutoMapper
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}