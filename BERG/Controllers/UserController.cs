using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BERG.Data;
using BERG.DP.UserManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels;
using BERG.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BERG.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserManagment userManagment;
        DataContext db;


        public UserController(IUserManagment userManagment, DataContext db)
        {
            this.db = db;
            this.userManagment = userManagment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var titles = db.Titles.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();

            var model = new RegisterViewModel()
            {
                Titles = titles
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userManagment.CreateUser(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Greška pri kreiranju korisnika.");
                }
            }
            var titles = db.Titles.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();
            model.Titles = titles;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await userManagment.LoginUser(model.Email, model.Password))
                {
                    return RedirectToAction("Index", "Appointment");
                }

                else
                {
                    ModelState.AddModelError("", "Pokusajte ponovo.");
                }
            }

            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await userManagment.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            User logged = await userManagment.GetLogged();
            var model = new ProfileViewModel()
            {
                Firstname = logged.Firstname,
                Lastname = logged.Lastname,
                TitleID = logged.TitleID,
                Code = logged.Code,
                UserID = logged.Id
            };
            var titles = db.Titles.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();
            model.Titles = titles;

            return View(model);
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                userManagment.UpdateUser(model);


                return RedirectToAction("Index", "Home");
            }

            var titles = db.Titles.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name.ToString()
            }).ToList();
            model.Titles = titles;

            return View(model);
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            var users = userManagment.ListAllUsers();
            return View(users.AsEnumerable());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await userManagment.DeleteUser(id);
            return RedirectToAction("Index", "Home");
        }
    }
}