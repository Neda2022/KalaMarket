using Endpoint.Site.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Products.Commands.AddNewProduct;
using Store.Application.Services.Products.Commands.EditeProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        
        public IActionResult Index(int Page=1,int PageSize=20)
        {
            return View(_productFacad.GetProductForAdminService.Execute(Page,PageSize).Data);
        }
        public IActionResult Detail(long Id)
        {
            return View(_productFacad.GetProductDetailForAdminService.Execute(Id).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacad.AddNewProductService.Execute(request));
        }

        [HttpPost]
        public IActionResult Edit(EditProductDetailForAdmiViewModel model)
        {
            return Json(_productFacad.EditeProductService.Execute(new RequestEditProductDto{ 
            
               Id=model.Id,
               Brand=model.Brand,
               Description=model.Description,
               Displayed=model.Displayed,
               Inventory=model.Inventory,
               Name=model.Name,
               Price=model.Price
            
            
            }));
        }
        public IActionResult Delete(long Id)
        {
            return Json(_productFacad.RemoveProductDetailService.Execute(Id));
        }
    }
}