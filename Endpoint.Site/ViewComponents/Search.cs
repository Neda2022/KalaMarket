using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class Search: ViewComponent
    {
        private readonly IProductFacad _productFacad;
        public Search(IProductFacad productFacad)
        {
            _productFacad = productFacad;

        }
        public IViewComponentResult Invoke() {
            return View(viewName: "Search", _productFacad.GetCategoryService.Execute().Data);
        }
    }
}
