using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using DreamTravel.Areas.Admin.Models;
using DTOLayer.DTOs.AdminDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
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
    }
}
