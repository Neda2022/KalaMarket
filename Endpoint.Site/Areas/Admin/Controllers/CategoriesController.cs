using Endpoint.Site.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Products.Commands.EditProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;
        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
      
        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }
        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId,string Name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_productFacad.RemoveProductService.Execute(Id));
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            return Json(_productFacad.EditProductService.Execute(new RequestEditProductDto
            {
                Id=model.Id,
                Name=model.Name,

            }));
        }
        
       

    }
}
