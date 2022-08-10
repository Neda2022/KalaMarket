using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Store.Common;
using Store.Domain.Entities.Users;

namespace Store.Application.Services.Users.Commands.RegisterUsers
{
    public class RequestRegisterUservalidator : AbstractValidator<RequestRegisterUserDto>
    {
    
        public RequestRegisterUservalidator(RequestRegisterUserDto request)
        {
           
        RuleFor(request => request.FullName)
                .NotEmpty()
                .WithMessage("نام و نام خانوادگی را وارد نماید!");
            RuleFor(request => request.Email)
                .NotEmpty()
                .WithMessage("ایمیل را وارد نمایید!")
                .EmailAddress()
                .WithMessage("فرمت ایمیل نامعتبر است")
              ;
            RuleFor(request => request.Password)
                  .NotEmpty()
                  .WithMessage(" رمز عبور را وارد نمایید  !");

            RuleFor(request => request.RePasword)
                   .NotEmpty()
                   .WithMessage("تکرار رمز عبور را وارد نمایید  !");
            RuleFor(request => request.RePasword)
                 .Equal(request.Password);
                 
        }

    }
  

}
