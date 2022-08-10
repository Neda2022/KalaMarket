using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Store.Common.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.RegisterUsers
{


    public interface IRegisterUserService
    {

        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);

    }


}
