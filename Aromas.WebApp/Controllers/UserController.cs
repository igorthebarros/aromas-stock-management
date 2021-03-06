using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.MVC.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aromas.MVC.Controllers
{
    [Route ("api")]
    public class UserController : Controller
    {
        readonly IMapper _mapper;
        private readonly IUserAppService _userAppService;
        private readonly ITokenAppService _tokenService;

        public UserController(IUserAppService userAppService, ITokenAppService tokenService, IMapper mapper)
        {
            _userAppService = userAppService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [Route("User/Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(string email, string password)
        {
            var user = await _userAppService.CheckUser(email, password);

            if(user == null)
                return NotFound(new { message = "Not Found"});

            var token = _tokenService.GenerateToken(user);

            user.Password = "";

            return Ok();
        }

        [HttpGet]
        [Route("User")]
        public ActionResult Index()
        {
            var users = _userAppService.GetAll();
            var model = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return Ok(model);
        }
        
        [HttpGet]
        [Route("User/Create")]
        public ActionResult Create()
        {
            try
            {
                var model = new UserViewModel();
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
        [Route("User/Create")]
        public ActionResult Create([FromBody] UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = ($"An error occured: Model is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                var user = _mapper.Map<User>(model);

                if (user == null)
                {
                    TempData["error"] = "Error while saving user.";
                    return RedirectToAction(nameof(Index));
                }

                _userAppService.Create(user);
                TempData["success"] = "New user created!";
                return Ok(RedirectToAction(nameof(Index)));
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("User/Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var model = _userAppService.GetById(id);

                if (!ModelState.IsValid && model == null)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                var user = _mapper.Map<UserViewModel>(model);
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("User/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _userAppService.GetById(id);

                if (model == null)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                var user = _mapper.Map<UserViewModel>(model);

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("User/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            try
            {
                User dataBaseUser = _userAppService.GetById(user.Id);

                if (!ModelState.IsValid && dataBaseUser == null)
                {
                    TempData["error"] = ($"An error occured: Model is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBaseUser.Id = user.Id;
                dataBaseUser.Name = user.Name;
                dataBaseUser.Surname = user.Surname;
                dataBaseUser.Email = user.Email;
                dataBaseUser.Password = user.Password;
                dataBaseUser.Active = user.Active;
                dataBaseUser.UpdatedAt = user.UpdatedAt;
                //TODO: Add policy when policies is added

                _userAppService.Update(dataBaseUser);
                TempData["success"] = "User updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("User/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _userAppService.GetById(id);

                if (!ModelState.IsValid && model == null)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                var user = _mapper.Map<UserViewModel>(model);
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["error"] = ($"An error occured: {0}", ex);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpDelete]
        [Route("User/Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(UserViewModel user)
        {
            try
            {
                User dataBaseUser = _userAppService.GetById(user.Id);

                if (!ModelState.IsValid && dataBaseUser == null)
                {
                    TempData["error"] = ($"An error occured: ModelState is invalid.");
                    return RedirectToAction(nameof(Index));
                }

                dataBaseUser.Id = user.Id;
                dataBaseUser.Name = user.Name;
                dataBaseUser.Surname = user.Surname;
                dataBaseUser.Email = user.Email;
                dataBaseUser.Password = user.Password;
                dataBaseUser.Active = user.Active;
                dataBaseUser.UpdatedAt = user.UpdatedAt;
                //TODO: Add policy when policies is added

                _userAppService.Delete(dataBaseUser);
                TempData["success"] = "User deleted successfully!";
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