using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Store.Application.Services.Users.UserLogin.UserLoginService;

namespace Store.Application.Services.Users.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserLoginDto> Execute(string UserName, string Password);
    }
}
