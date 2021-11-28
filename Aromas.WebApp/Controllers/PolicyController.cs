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
    [Route ("api")]
    public class PolicyController : Controller
    {
        readonly IMapper _mapper;
        private readonly IPolicyAppService _policyAppService;

        public PolicyController(IPolicyAppService policyAppService, IMapper mapper)
        {
            _policyAppService = policyAppService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Policy")]
        public ActionResult Index()
        {
            var policies = _policyAppService.GetAll();
            var model = _mapper.Map<IEnumerable<PolicyViewModel>>(policies);

            return Ok(model);
        }

        [HttpGet]
        [Route("Policy/Create")]
        public ActionResult Create()
        {
            try
            {
                var model = new PolicyViewModel();
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
        [Route("Policy/Create")]
        public ActionResult Create([FromBody] PolicyViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = ($"An error occured: Model is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                var policy = _mapper.Map<Policy>(model);

                if (policy == null)
                {
                    TempData["error"] = "Error while saving policy.";
                    return RedirectToAction(nameof(Index));
                }

                _policyAppService.Create(policy);
                TempData["success"] = "New policy created!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Policy/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _policyAppService.GetById(id);

                if (model == null)
                {
                    TempData["error"] = "Policy not found.";
                    return RedirectToAction(nameof(Index));
                }

                var policy = _mapper.Map<PolicyViewModel>(model);

                return View(policy);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("Policy/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PolicyViewModel policy)
        {
            try
            {
                Policy dataBasePolicy = _policyAppService.GetById(policy.Id);

                if (!ModelState.IsValid && dataBasePolicy == null)
                {
                    TempData["error"] = ($"An error occured: Model is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBasePolicy.Id = policy.Id;
                dataBasePolicy.Name = policy.Name;
                dataBasePolicy.Active = policy.Active;
                dataBasePolicy.UpdatedAt = policy.UpdatedAt;
             
                _policyAppService.Update(dataBasePolicy);
                TempData["success"] = "Policy updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Policy/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _policyAppService.GetById(id);

                if (!ModelState.IsValid && model == null)
                {
                    TempData["error"] = "Policy not found.";
                    return RedirectToAction(nameof(Index));
                }

                var policy = _mapper.Map<PolicyViewModel>(model);
                return View(policy);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpDelete]
        [Route("Policy/Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(PolicyViewModel policy)
        {
            try
            {
                Policy dataBasePolicy = _policyAppService.GetById(policy.Id);

                if (!ModelState.IsValid && dataBasePolicy == null)
                {
                    TempData["error"] = ($"An error occured: ModelState is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBasePolicy.Id = policy.Id;
                dataBasePolicy.Name = policy.Name;
                dataBasePolicy.Active = policy.Active;
                
                _policyAppService.Delete(dataBasePolicy);
                TempData["success"] = "Policy deleted successfully!";
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
