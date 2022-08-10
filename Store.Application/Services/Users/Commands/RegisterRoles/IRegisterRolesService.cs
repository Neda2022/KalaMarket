using Store.Application.Interfaces.Context;
using Store.Application.Services.Users.Commands.RegisterUsers;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.RegisterRoles
{
   public interface IRegisterRolesService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterRoleDto request);
    }
    public class RegisterRolesService : IRegisterRolesService
    {
        private readonly IDataBaseContext _context;
        public RegisterRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterRoleDto request)
        {
            try
            {
                User user = new User()
                {
                    Id=request.Id,

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
                    Message = "ثبت نقش جدید انجام شد",
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
                    Message = "ثبت نقش جدید انجام نشد !"
                };

            }

        }
    }
    }

