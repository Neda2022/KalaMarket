using Endpoint.Site.Areas.Admin.Models;
using Endpoint.Site.Models.ViewModel;
using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IUsersFacad _userFacad;
        public ProfileController(IUsersFacad usersFacad)
        {
            _userFacad = usersFacad;
        }
        public IActionResult Index()
        {
            long UserId = ClaimUtility.GetUserId(User).Value;
            ViewBag.User = UserId;
            return View(_userFacad.GetProfileUser.Execute(UserId).Data);
        }

        [HttpPost]
        public IActionResult Edit(EditUserProfileViewModel edit)
        {
            return Json(_userFacad.EditUserProfile.Execute(new UserEditDto
            {

                Email=edit.Email,
                FullName=edit.Fullname,
                Id=edit.UserId,



            }));
        }
    }
}
