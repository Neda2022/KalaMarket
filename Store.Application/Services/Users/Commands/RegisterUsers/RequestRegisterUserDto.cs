using System.Collections.Generic;

namespace Store.Application.Services.Users.Commands.RegisterUsers
{
    public class RequestRegisterUserDto
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }


    }


}
