using Endpoint.Site.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Users.Commands.RegisterUsers;
using Store.Application.Services.Users.UserLogin;
using Store.Common.Dto;
using Store.Common.Roles;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Endpoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUsersFacad _usersFacad;
        
        public AuthenticationController(IUsersFacad usersFacad)
        {
            _usersFacad = usersFacad;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
       
        public IActionResult Signup(SignupViewModel request)
        {
           
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.RePassword))
            {
                return Json(new ResultDto { Success = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { Success = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDto { Success = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDto { Success = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { Success = true, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }


           //Register
            var signUpResult = _usersFacad.RegisterUserService.Execute(new RequestRegisterUserDto
            {
              Email=request.Email,
              FullName= request.FullName,
              Password= request.Password,
              RePasword= request.RePassword,
              roles=new List<RolesInRegisterUserDto>()
              {
                  new RolesInRegisterUserDto{
                
                     Id=3,
                    Name=UserRole.Customer

                  }
                 
              }
            });
            //LogIn
            if (signUpResult.Success == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signUpResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email,request.Email),
                    new Claim(ClaimTypes.Name,request.FullName),
                    new Claim(ClaimTypes.Role,UserRole.Customer),

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principlal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principlal, properties);
            }
            return Json(signUpResult);
        }

        [HttpGet]
        public IActionResult Signin(string ReturnUrl="/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }
        [HttpPost]
        
        public IActionResult Signin(LoginViewModel model, string url = "/")
        {
            var signUpResult = _usersFacad.UserLoginService.Execute(model.Email, model.Password);
            if (signUpResult.Success == true)
            {
                var claims = new List<Claim>()
                {new Claim(ClaimTypes.NameIdentifier,signUpResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Name,signUpResult.Data.Name),
                };
                foreach (var item in signUpResult.Data.Roles)
                {

                    claims.Add(new Claim(ClaimTypes.Role, item));

                }
                var identity =new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principle, properties);
            }
            return Json(signUpResult);
        }

        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
