using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="نام و نام خانوادگی را وارد کنید!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "ایمیل معتبر را وارد کنید!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "پسورد را وارد کنید!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "تکرار رمز عبور و رمز عبور  برابر نیست!")]
        public string RePasword { get; set; }
        public long RoleId { get; set; }
    }
}
