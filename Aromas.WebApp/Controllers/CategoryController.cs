using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Aromas.MVC.Controllers
{
    [Route("api")]
    public class CategoryController : Controller
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

            return Ok(model);
        }

        [HttpGet]
        [Route("Category/Create")]
        public ActionResult Create()
        {
            try
            {
                var model = new CategoryViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Category/Create")]
        public ActionResult Create([FromBody] CategoryViewModel model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);

                if (category == null)
                {
                    TempData["error"] = "Error while saving category";
                    return RedirectToAction(nameof(Index));
                }

                _categoryAppService.Create(category);
                TempData["success"] = "New category created!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Category/Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var model = _categoryAppService.GetById(id);

                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Category not found.";
                    return RedirectToAction(nameof(Index));
                }

                var category = _mapper.Map<CategoryViewModel>(model);
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Category/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _categoryAppService.GetById(id);

                if (model == null)
                {
                    TempData["error"] = "Category not found.";
                    TempData["error"] = "Category not found.";
                    return RedirectToAction(nameof(Index));
                }

                var category = _mapper.Map<CategoryViewModel>(model);

                return View(category);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("Category/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            try
            {
                Category dataBaseCategory = _categoryAppService.GetById(category.Id);

                if (!ModelState.IsValid && dataBaseCategory == null)
                {
                    TempData["error"] = ($"An error occured: Model is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBaseCategory.Id = category.Id;
                dataBaseCategory.Name = category.Name;
                dataBaseCategory.SubCategory = category.SubCategory;
                dataBaseCategory.UpdatedAt = category.UpdatedAt;
                dataBaseCategory.Active = category.Active;
                //TODO: Add policy when policies is added

                _categoryAppService.Update(dataBaseCategory);
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Category/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _categoryAppService.GetById(id);

                if (!ModelState.IsValid && model == null)
                {
                    TempData["error"] = "Category not found.";
                    return RedirectToAction(nameof(Index));
                }

                var category = _mapper.Map<CategoryViewModel>(model);
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("Category/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel category)
        {
            try
            {
                Category dataBaseCategory = _categoryAppService.GetById(category.Id);

                if (!ModelState.IsValid && dataBaseCategory == null)
                {
                    TempData["error"] = ($"An error occured: ModelState is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBaseCategory.Id = category.Id;
                dataBaseCategory.Name = category.Name;
                dataBaseCategory.SubCategory = category.SubCategory;
                dataBaseCategory.UpdatedAt = category.UpdatedAt;
                dataBaseCategory.Active = category.Active;
                //TODO: Add policy when policies is added

                _categoryAppService.Delete(dataBaseCategory);
                TempData["success"] = "Category deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
