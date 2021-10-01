using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Aromas.MVC.Controllers
{
    [Route ("api")]
    public class ProductController : Controller
    {
        readonly IMapper _mapper;
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Product")]
        public ActionResult Index()
        {
            var products = _productAppService.GetAll();
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return Ok(model);
        }

        [HttpGet]
        [Route("Product/Create")]
        public ActionResult Create()
        {
            try
            {
                var model = new ProductViewModel();
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
        [Route("Product/Create")]
        public ActionResult Create([FromBody]ProductViewModel model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);

                if (product == null)
                {
                    TempData["error"] = "Error while saving product";
                    return RedirectToAction(nameof(Index));
                }

                _productAppService.Create(product);
                TempData["success"] = "New product created!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Product/Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var model = _productAppService.GetById(id);

                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Product not found.";
                    return RedirectToAction(nameof(Index));
                }

                var product = _mapper.Map<ProductViewModel>(model);
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Product/GetProductByIsInStock/{isInStock}")]
        public ActionResult GetProductByInStock(bool isInStock)
        {
            try
            {
                List<Product> model = _productAppService.GetByIsInStock(isInStock);
                
                if (model == null) 
                {
                    TempData["error"] = "Fail!";
                    return RedirectToAction(nameof(Index));
                }
                    
                var product = _mapper.Map<List<ProductViewModel>>(model);
                return Ok(product);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Product/GetProductByCategoryId/{id}")]
        public ActionResult GetProductByCategoryId(int id)
        {
            try
            {
                List<Product> model = _productAppService.GetByCategoryId(id);

                if (model == null)
                {
                    TempData["error"] = "Fail!";
                    return RedirectToAction(nameof(Index));
                }

                var product = _mapper.Map<List<ProductViewModel>>(model);
                return Ok(product);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Product/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _productAppService.GetById(id);

                if (model == null)
                {
                    TempData["error"] = "Product not found.";
                    return RedirectToAction(nameof(Index));
                }

                var product = _mapper.Map<ProductViewModel>(model);

                return Ok(product);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("Product/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {
                Product dataBaseProduct = _productAppService.GetById(product.Id);

                if (!ModelState.IsValid && dataBaseProduct == null)
                {
                    TempData["error"] = ($"An error occured: Model is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBaseProduct.Id = product.Id;
                dataBaseProduct.Name = product.Name;
                dataBaseProduct.IsInStock = product.IsInStock;
                dataBaseProduct.StockQuantity = product.StockQuantity;
                dataBaseProduct.UpdatedAt = product.UpdatedAt;
                dataBaseProduct.CategoryId = product.CategoryId;
                //TODO: Add policy when policies is added

                _productAppService.Update(dataBaseProduct);
                TempData["success"] = "Product updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Product/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _productAppService.GetById(id);

                if (!ModelState.IsValid && model == null)
                {
                    TempData["error"] = "Product not found.";
                    return RedirectToAction(nameof(Index));
                }

                var product = _mapper.Map<ProductViewModel>(model);
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("Product/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel product)
        {
            try
            {
                Product dataBaseProduct = _productAppService.GetById(product.Id);

                if (!ModelState.IsValid && dataBaseProduct == null)
                {
                    TempData["error"] = ($"An error occured: ModelState is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBaseProduct.Id = product.Id;
                dataBaseProduct.Name = product.Name;
                dataBaseProduct.IsInStock = product.IsInStock;
                dataBaseProduct.StockQuantity = product.StockQuantity;
                dataBaseProduct.UpdatedAt = product.UpdatedAt;
                dataBaseProduct.CategoryId = product.CategoryId;
                //TODO: Add policy when policies is added

                _productAppService.Delete(dataBaseProduct);
                TempData["success"] = "Product deleted successfully!";
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
