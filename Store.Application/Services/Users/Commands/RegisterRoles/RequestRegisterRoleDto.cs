using Store.Application.Services.Users.Commands.RegisterUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.RegisterRoles
{
   public class RequestRegisterRoleDto
    {
        public List<RolesInRegisterUserDto> roles { get; set; }
        public long Id { get; set; }

    }
}
