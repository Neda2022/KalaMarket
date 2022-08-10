using Endpoint.Site.Areas.Admin.Models;
using Store.Application.Services.Profile;
using Store.Application.Services.Users.Commands.EditUser;
using Store.Application.Services.Users.Commands.RegisterRoles;
using Store.Application.Services.Users.Commands.RegisterUsers;
using Store.Application.Services.Users.Commands.RemoveUser;
using Store.Application.Services.Users.Commands.UserSatusChange;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Application.Services.Users.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
    public interface IUsersFacad
    {
         IEditUserService EditUserService { get; }
         IRegisterUserService RegisterUserService { get; }
         IRemoveUserService RemoveUserService { get; }
         IUserLoginService UserLoginService { get; }
         IUserSatusChangeService UserSatusChangeService { get; }
         IGetRolesService GetRolesService { get; }
         IGetUsersService GetUsersService { get; }
         IRegisterRolesService RegisterRolesService { get; }
        IGetProfileUser GetProfileUser { get; }
        IEditUserProfile EditUserProfile { get; }
    }
}
