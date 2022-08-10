using Endpoint.Site.Areas.Admin.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Users.Commands.EditUser;
using Store.Application.Services.Users.Commands.RegisterRoles;
using Store.Application.Services.Users.Commands.RegisterUsers;
using Store.Application.Services.Users.Commands.RemoveUser;
using Store.Application.Services.Users.Commands.UserSatusChange;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Store.Application.Services.Users.Queries.GetUsers.GetUsersService;

namespace Endpoint.Site.Areas.Admin.Controllers
{
   [Area("Admin")]
   // [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersFacad _usersFacad;

        public UsersController(IUsersFacad usersFacad)
        {
            _usersFacad = usersFacad;
       
        }

        public IActionResult Index(string serchkey, int page = 1, int pageSize=20)
        {
            return View(_usersFacad.GetUsersService.Execute(new RequestGetUserDto
            {
                page = page,
                SearchKey = serchkey,
            }, pageSize));
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(_usersFacad.GetRolesService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Register(RequestRegisterRoleDto request, RgisterRoles model)
        {

                var result = _usersFacad.RegisterRolesService.Execute(new RequestRegisterRoleDto
                {

                   
                    roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id=model.RoleId
                        }
                   },
                   
                });

                return Json(result);
            }
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_usersFacad.GetRolesService.Execute().Data, "Id", "Name");
            return View();
        }




        [HttpPost]
        public IActionResult Create(RequestRegisterUserDto request , RegisterViewModel model)
        {

                var result = _usersFacad.RegisterUserService.Execute(new RequestRegisterUserDto
                {

                    Email =request.Email,
                    FullName =request.FullName,
                    roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id=model.RoleId
                        }
                   },
                   Password =request.Password,
                   RePasword =model.RePasword,
                });
                
                return Json(result);
            }
       
        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_usersFacad.RemoveUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_usersFacad.UserSatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel model)
        {
            return Json(_usersFacad.EditUserService.Execute(new RequestEdituserDto
            {
                Fullname =model.Fullname,
                UserId = model.UserId,
                Email=model.Email,
            }));
        }

    }

}

