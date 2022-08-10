using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Models
{
  public  interface IEditUserProfile
    {
        ResultDto Execute(UserEditDto request);     
    }

    public class EditUserProfile : IEditUserProfile
    {
        private readonly IDataBaseContext _context;
        public EditUserProfile(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(UserEditDto request)
        {
            var user = _context.Users.Find(request.Id);
            if (user == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "کاربر یافت نشد!"
                };
            }
            user.Id = request.Id;
                user.FullName = request.FullName;
                user.Email = request.Email;
                _context.SaveChanges();
                return new ResultDto()
                {
                    Success = true,
                    Message = "ویرایش با موفقیت انجام شد!"
                };
            
        }
    }

    public class UserEditDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

    }
}
