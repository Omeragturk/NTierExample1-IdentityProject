using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierExample.BLL.IServices;
using NTierExample.DTO.UserDtos;
using NTierExample.MvcUI.Extensions;
using NTierExample.ViewModel.UserVms;

namespace NTierExample.MvcUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public UsersController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var result = await _adminService.GetAllUsersAsync();

            if (result.HasError)
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            return View(result.Model);
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _adminService.GetUserAsync(id);

            if (result.HasError)
            {
                return RedirectToAction("Index");
            }

            return View(result.Model);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateVm userCreateVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userCreateVm);
                }

                var loginModel = HttpContext.Session.ModelParse<LoginDto>("user");

                var user = _mapper.Map<UserCreateDto>(userCreateVm);
                user.CreatedBy = loginModel.UserName;

                var result = await _adminService.CreateUserAsync(user);

                if (result.HasError)
                {
                    return View(userCreateVm);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(userCreateVm);
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserUpdateVm userUpdateVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userUpdateVm);
                }

                var loginModel = HttpContext.Session.ModelParse<LoginDto>("user");

                var user = _mapper.Map<UserUpdateDto>(userUpdateVm);
                user.UpdatedBy = loginModel.UserName;

                var result = await _adminService.UpdateUserAsync(user);

                if (result.HasError)
                {
                    return View(userUpdateVm);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _adminService.DeleteUserAsync(id);

            if (result.HasError)
            {
                TempData["Errors"] = result.Errors;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
