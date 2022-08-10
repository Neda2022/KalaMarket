using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Models.ViewModel
{
    public class EditUserProfileViewModel
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }

    }
}
