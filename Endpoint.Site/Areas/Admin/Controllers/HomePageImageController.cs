using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Common.Queries.EditeHomeImage;
using Store.Application.Services.HomePage.AddHomeImage;
using Store.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImageController : Controller
    {
        private readonly IAddHomeImageFacad _addHomeImageFacad;
       
        public HomePageImageController(IAddHomeImageFacad addHomeImageFacad)
        {
            _addHomeImageFacad = addHomeImageFacad;
        }
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
          
            return View(_addHomeImageFacad.GetAllHomePageImagesService.Execute(page, pageSize).Data);
        }
       
        
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(IFormFile file, ImageLocation imageLocation , string link)
        {
            _addHomeImageFacad.AddHomeImageService.Execute(new RequestAddPageImageDto {
           
                file = file,
                ImageLocation = imageLocation,
                Link = link,
           
        });
            return View();

        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_addHomeImageFacad.RemoveHomePageImageService.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(long Id , string link)
        {
            return Json(_addHomeImageFacad.EditeHomeImageService.Execute(new RequestHomePageDto { 
            
            Id=Id,
            Link=link,
            
            
            }));
        }
    }
}
