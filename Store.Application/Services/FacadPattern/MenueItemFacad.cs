using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Common.Queries.GetMenuItem;
using Store.Application.Services.Common.Queries.GetMenuItemForMobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.FacadPattern
{
   public class MenueItemFacad: IMenueItemFacad
    {
        private readonly IDataBaseContext _context;
        public MenueItemFacad(IDataBaseContext context)
        {
            _context = context;

        }
        private IGetMenuItemService _getMenuItemService;
        public IGetMenuItemService GetMenuItemService { 
            get
            {
                return _getMenuItemService = _getMenuItemService ?? new GetMenuItemService(_context);

            } 
        }
        private IGetMenuItemForMobileService _getMenuItemForMobileService;
        public IGetMenuItemForMobileService GetMenuItemForMobileService
        {
            get
            {
                return _getMenuItemForMobileService = _getMenuItemForMobileService ?? new GetMenuItemForMobileService(_context);

            }
        }
        
    }
}
