using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierExample.BLL.IServices;
using NTierExample.DTO.UserDtos;
using NTierExample.MvcUI.Extensions;
using NTierExample.MvcUI.Models;
using NTierExample.ViewModel.UserVms;
using System.Diagnostics;

namespace NTierExample.MvcUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            var result = await _userService.Login(loginVm);

            if (result.HasError)
            {
                return View(loginVm);
            }

            HttpContext.Session.JsonParse<LoginDto>("user", result.Model);

            return RedirectToAction("Index", "Home", new {Area = "Admin"});
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogOut();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
