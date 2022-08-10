using Store.Application.Interfaces.Context;
using Store.Common.Dto;

namespace Store.Application.Services.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.Fullname;
            user.Email = request.Email;
            _context.SaveChanges();

            return new ResultDto()
            {
                Success = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }
}
