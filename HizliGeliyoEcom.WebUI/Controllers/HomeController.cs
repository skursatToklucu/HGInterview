using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.DataAccess.Repositories.Concrete;
using HizliGeliyoEcom.Entities.Entities;
using HizliGeliyoEcom.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HizliGeliyoEcom.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, ProjectContext context, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _userRepository = new UserRepository(context, httpContext);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Customer customer, string email)
        {
            if (_userRepository.CheckEmail(customer, email) && _userRepository.CheckPassword(customer, customer.Password))
            {
                Guid getID = _userRepository.GetByDefault(x => x.Email == email).ID;
                await HttpContext.SignInAsync(_userRepository.LoginClaims(customer));
                HttpContext.Session.SetString("CustomerID", getID.ToString());
                return RedirectToAction("Index", "Shop");
            }
            else
            {
                ViewBag.Hata = "Hatalı Giriş Lütfen tekrar deneyin";
                return View(customer);
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Customer customer)
        {
            if (_userRepository.Any(x => x.Email == customer.Email))
            {
                TempData["Message"] = "Bu Mail adresi zaten kayıtlı!!";
                return View();
            }
            else
            {
                _userRepository.SendMail(_userRepository.CreateCustomer(customer));
                _userRepository.Add(customer);

                return RedirectToAction("Login", "Home");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
