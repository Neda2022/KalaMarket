using Store.Application.Services.Common.Queries.GetMenuItem;
using Store.Application.Services.Common.Queries.GetMenuItemForMobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
   public interface IMenueItemFacad
    {
        IGetMenuItemService GetMenuItemService { get; }
        IGetMenuItemForMobileService GetMenuItemForMobileService { get; }
    }
}
