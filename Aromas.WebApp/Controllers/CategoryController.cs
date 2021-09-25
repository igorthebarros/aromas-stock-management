using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromas.MVC.Controllers
{
    public class CategoryController
    {
        readonly IMapper _mapper;
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService, IMapper mapper) 
        {
            _categoryAppService = categoryAppService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Category")]
        public ActionResult Index()
        {
            var categories = _categoryAppService.GetAll();
            var model = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return View(model);
        }




    }
}
