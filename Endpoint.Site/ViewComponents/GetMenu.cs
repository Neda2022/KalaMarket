using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class GetMenu:ViewComponent
    {
        public readonly IMenueItemFacad _menueItemFacad;
        public GetMenu(IMenueItemFacad menueItemFacad)
        {
            _menueItemFacad = menueItemFacad;
        }
        public IViewComponentResult Invoke()
        {
            var menuItem = _menueItemFacad.GetMenuItemService.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }
    }
}
