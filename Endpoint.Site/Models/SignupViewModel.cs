using Store.Application.Services.Users.Commands.RegisterUsers;
using Store.Common.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Models
{
    public class SignupViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }

    }
}
