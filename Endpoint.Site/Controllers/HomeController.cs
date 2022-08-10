using Endpoint.Site.Models;
using Endpoint.Site.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderFacad _sliderFacad;
        private readonly IAddHomeImageFacad _addHomeImageFacad;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger,
            ISliderFacad sliderFacad,
            IAddHomeImageFacad addHomeImageFacad,
            IProductFacad productFacad)
        {
            _logger = logger;
            _sliderFacad = sliderFacad;
            _addHomeImageFacad = addHomeImageFacad;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _sliderFacad.GetSliderService.Execute().Data,
                PageImage = _addHomeImageFacad.GetHomePageImagesService.Execute().Data,
                Camera = _productFacad.GetProductForSiteService.Execute(Ordering.theNewest, null, 1, 6, 10071).Data.Products,
                Mobile = _productFacad.GetProductForSiteService.Execute(Ordering.theNewest, null, 1, 6, 10070).Data.Products,
                HomeTools = _productFacad.GetProductForSiteService.Execute(Ordering.theNewest, null, 1, 6, 10086).Data.Products,
                 LapTop=_productFacad.GetProductForSiteService.Execute(Ordering.theNewest,null,1,6, 10068).Data.Products,
            };
            return View(homePage);  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
