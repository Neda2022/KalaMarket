using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }


    }
}
