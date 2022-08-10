using Endpoint.Site.Areas.Admin.Models;
using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
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

namespace Store.Application.Services.Users.FacadPattern
{
    public class UsersFacad: IUsersFacad
    {
        private readonly IDataBaseContext _context;
        public UsersFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IEditUserService _editUserService;
        public IEditUserService EditUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);

            }
        }
        private IRegisterUserService _registerUserService;
         public  IRegisterUserService RegisterUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);

            } 
        }
        private IRemoveUserService _removeUserService;
        public IRemoveUserService RemoveUserService {
            get
            {
                return _removeUserService = _removeUserService ?? new RemoveUserService(_context);
            
            }
        }
        private  IUserLoginService _userLoginService;
        public IUserLoginService UserLoginService
        {
            get
            {
                return _userLoginService = _userLoginService ??new UserLoginService(_context);
            }
        }
        private IUserSatusChangeService _userSatusChangeService;
        public IUserSatusChangeService UserSatusChangeService
        {
            get
            {
                return _userSatusChangeService =_userSatusChangeService?? new UserSatusChangeService(_context);       
            }
        }
        private IGetRolesService _getRolesService;
        public IGetRolesService GetRolesService
        {
            get
            {
                return _getRolesService = _getRolesService ?? new GetRolesService(_context);
            }
        }
        private IGetUsersService _getUsersService;
        public IGetUsersService GetUsersService
        {
            get
            {
                return _getUsersService = _getUsersService ?? new GetUsersService(_context);
            }
        }

        private IRegisterRolesService _registerRolesService;
        public IRegisterRolesService RegisterRolesService
        {
            get
            {
                return _registerRolesService = _registerRolesService ?? new RegisterRolesService(_context);
            }
        }

        private IGetProfileUser _getProfileUser;
        public IGetProfileUser GetProfileUser
        {
            get
            {
                return _getProfileUser = _getProfileUser ?? new GetProfileUser(_context);
            }
        }
        private IEditUserProfile _editUserProfile;
        public IEditUserProfile EditUserProfile
        {
            get
            {
                return _editUserProfile = _editUserProfile ?? new EditUserProfile(_context);
            }
        }
    }
}
