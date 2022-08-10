using System.Collections.Generic;

namespace Store.Application.Services.Users.UserLogin
{
    public class ResultUserLoginDto
    {
        public long UserId { get; set; }
        public List<string> Roles { get; set; }
        public string Name { get; set; }


    }
}
