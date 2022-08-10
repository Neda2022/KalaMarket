using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderFacad _sliderFacad;
        public SliderController(ISliderFacad sliderFacad)
        {
            _sliderFacad = sliderFacad;
        }
      
        public IActionResult Index(int page=1, int pagesize=20)
        {
            return View(_sliderFacad.GetAllHomePageSliderService.Execute(page,pagesize).Data);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file, string link)
        {
            _sliderFacad.AddNewSliderService.Execute(file, link);
            return View();
        }
    }
}
