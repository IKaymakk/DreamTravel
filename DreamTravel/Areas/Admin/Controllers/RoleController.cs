using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DocumentFormat.OpenXml.Office2019.Drawing.Model3D;
using DocumentFormat.OpenXml.Wordprocessing;
using DreamTravel.Areas.Admin.Models;
using DTOLayer.DTOs.AdminDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto model)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = model.RoleName
                }); ;
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            ViewBag.ID = values.Id;
            UpdateRoleViewModel updateRole = new UpdateRoleViewModel
            {
                RoleID = values.Id,
                RoleName = values.Name
            };
            return View(updateRole);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleID);
            value.Name = model.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UserList()
        {
            var values = await _userManager.Users.AsNoTracking().ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            ViewBag.Kullanici = user.Id;
            TempData["Userid"] = user.Id;
            var roles = _roleManager.Roles.AsNoTracking().ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> viewmodel = new List<RoleAssignViewModel>();
            foreach (var x in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = x.Id;
                model.RoleName = x.Name;
                model.RoleExist = userRoles.Contains(x.Name);
                viewmodel.Add(model);
            }
            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var x in model)
            {
                if (x.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, x.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, x.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
