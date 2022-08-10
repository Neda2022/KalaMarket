using Store.Common.Roles;

namespace Store.Application.Services.Users.Commands.RegisterUsers
{
    public class RolesInRegisterUserDto
    {
        public long Id { get; set; }
        public virtual UserRole UserRole{get;set;}
        public string Name { get; set; }
    }


}
