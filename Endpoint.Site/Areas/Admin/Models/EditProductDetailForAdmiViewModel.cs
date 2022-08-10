using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Models
{
    public class EditProductDetailForAdmiViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
