using Microsoft.AspNetCore.Identity;
using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using Store.Common.HashPassword;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Store.Application.Services.Users.Commands.RegisterUsers
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {

            try
            {
                RequestRegisterUservalidator validator = new RequestRegisterUservalidator(request);
                FluentValidation.Results.ValidationResult resultvalid = validator.Validate(request);

                if (!resultvalid.IsValid)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        Success = false,
                        Message = "فیلدهای مورد نظر را پر کنید!",
                    };
                    
                }
                    var passwordHasher = new PasswordHasher();
                    var hashedPassword = passwordHasher.HashPassword(request.Password);
                    User user = new User()
                    {
                        Email = request.Email,
                        FullName = request.FullName,
                        Password = hashedPassword,
                        IsActive = true,

                    };
                    List<UserInRole> userInRoles = new List<UserInRole>();

                    foreach (var item in request.roles)
                    {
                        var roles = _context.Roles.Find(item.Id);
                        userInRoles.Add(new UserInRole
                        {
                            Role = roles,
                            RoleId = roles.Id,
                            User = user,
                            UserId = user.Id,
                        });
                    }
                    user.UserInRoles = userInRoles;

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = user.Id,

                        },
                        Success = true,
                        Message = "ثبت نام کاربر انجام شد",
                    };
                
            }
            catch (Exception)
            {


                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    Success = false,
                    Message = "ثبت نام کاربرانجام نشد !"
                };

            }


            

        }
        

    }


}
