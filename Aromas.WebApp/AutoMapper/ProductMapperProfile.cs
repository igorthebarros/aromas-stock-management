using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;

namespace Aromas.MVC.AutoMapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
