using Store.Domain.Entities.Products;
using System.Collections.Generic;

namespace Store.Application.Services.Common.Queries.GetMenuItem
{
    public class MenuItemDto
    {
        public long CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Child { get; set; }
      


    }
   

}
