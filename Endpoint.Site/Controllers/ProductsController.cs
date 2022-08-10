using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Controllers
{
   
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productSiteFacad;
        public ProductsController(IProductFacad productSiteFacad)
        {
            _productSiteFacad = productSiteFacad;
        }
        public IActionResult Index(Ordering ordering,string searchKey, long? CatId = null, int page = 1, int pageSize = 20)
        {
            return View(_productSiteFacad.GetProductForSiteService.Execute(ordering,searchKey, page, pageSize, CatId).Data);
        }

        public IActionResult Detail(long Id)
        {
            return View(_productSiteFacad.GetProductDetailForSiteService.Execute(Id).Data);
        }
    }
}
