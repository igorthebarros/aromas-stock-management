using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromas.MVC.AutoMapper
{
    public class PolicyMapperProfile : Profile
    {
        public PolicyMapperProfile()
        {
            CreateMap<Policy, PolicyViewModel>().ReverseMap();
        }
    }
}
