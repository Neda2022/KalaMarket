using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class GetMobileMenu:ViewComponent
    {
        private readonly IMenueItemFacad _menueItemFacad;
        public GetMobileMenu(IMenueItemFacad menueItemFacad)
        {
            _menueItemFacad = menueItemFacad;
        }

        public IViewComponentResult Invoke()
        {
            var menueItem = _menueItemFacad.GetMenuItemForMobileService.Execute();
            return View(viewName: "GetMobileMenu", menueItem.Data);
        }
    }
}
