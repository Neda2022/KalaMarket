using Store.Application.Interfaces.Context;
using Store.Application.Services.Orders.Query.GetUserOrder;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Profile
{
  public  interface IGetProfileUser
    {
        ResultDto<List<ProfileUserDto>> Execute(long UserId);


    }
    public class GetProfileUser : IGetProfileUser
    {
        private readonly IDataBaseContext _context;
        public GetProfileUser(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<ProfileUserDto>> Execute(long UserId)
        {
          var user=  _context.Users.Where(p=>p.Id== UserId)
                .Select(p=>new ProfileUserDto { 
               
                Id=p.Id,
                FullName=p.FullName,
                Email=p.Email,
                }).ToList();
            return new ResultDto<List<ProfileUserDto>>

            {
                Data=user,
               Success=true,
            };
        }

       
        
    }
    public class ProfileUserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

    }
}
