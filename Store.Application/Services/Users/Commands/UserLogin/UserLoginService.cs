using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Common.HashPassword;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Users.UserLogin
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserLoginDto> Execute(string UserName, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {

                    },
                    Success = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید!"
                };
            }
            var user = _context.Users
                .Include(p => p.UserInRoles)
                .ThenInclude(p => p.Role)
                .Where(p => p.Email.Equals(UserName) && p.IsActive == true)
                .FirstOrDefault();
            if (user == null)
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {

                    },
                    Success = false,
                    Message = "کاربری با این ایمیل در سایت کالا مارکت ثبت نام نکرده است!"
                };
            }
            var passworgHasher = new PasswordHasher();
            bool resultVerifyPassword = passworgHasher.VerifyPassword(user.Password, Password);
            if (resultVerifyPassword == false)
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {

                    },
                    Success = false,
                    Message = "رمز وارد شده اشتباه است"
                };
            }
            List<string>roles = new List<string>();
            foreach (var item in user.UserInRoles)
            {
                roles.Add(item.Role.Name);
            }

            return new ResultDto<ResultUserLoginDto>()
            {
                Data = new ResultUserLoginDto()
                {
                    Roles = roles,
                    UserId = user.Id,
                    Name = user.FullName,
                },
                Success = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };
        }
       
    }
}
