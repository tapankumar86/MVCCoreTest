using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {

        IAuthService _authService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(IAuthService authService, IWebHostEnvironment webHostEnvironment)
        {
            _authService = authService;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Country> Countries()
        {

            List<Country> items = new List<Country>();
            items.Add(new Country
            {
                CountryNames = "India",
                CountryId = 1
            });
            items.Add(new Country
            {
                CountryNames = "China",
                CountryId = 2
            });
            items.Add(new Country
            {
                CountryNames = "America",
                CountryId = 3
            });
            items.Add(new Country
            {
                CountryNames = "Japan",
                CountryId = 4
            });
            items.Add(new Country
            {
                CountryNames = "Nepal",
                CountryId = 5
            });
            return items;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _authService.AuthenticateUser(model.Email, model.Password);
            if (user != null)
            {
                if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "User" });
                }
            }

            return View();
        }

        public IActionResult SignUp()
        {
            ViewBag.CountryList = Countries();
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var userCheck = _authService.FindByMail(model.Email);
                if (userCheck == null)
                {
                    string uniqueFileName = UploadedFile(model);

                    User user = new User
                    {
                        Name = model.Name,
                        Gender = model.Gender,
                        MobileNo = model.MobileNo,
                        UserName = model.Email,
                        Email = model.Email,
                        Photo = uniqueFileName,
                        Designation = model.Designation,
                        Country = model.CountryName
                    };
                    bool result = _authService.CreateUser(user, model.Password);
                    if (result)
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ViewBag.Error = "Email already exists.";
                }
            }
            else
            {
                ModelState.AddModelError("message", string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)));
            }

            ViewBag.CountryList = Countries();
            return View(model);
        }

        private string UploadedFile(UserModel model)
        {
            string uniqueFileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Unauthorize()
        {
            return View();
        }

        public IActionResult LogOutComplete()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOut();
            return RedirectToAction("LogOutComplete");
        }

    }
}
