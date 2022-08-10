using Store.Application.Services.Common.Queries.GetCategory;
using Store.Application.Services.Products.Commands.AddNewCategory;
using Store.Application.Services.Products.Commands.AddNewProduct;
using Store.Application.Services.Products.Commands.EditeProduct;
using Store.Application.Services.Products.Commands.EditProduct;
using Store.Application.Services.Products.Commands.RemoveProduct;
using Store.Application.Services.Products.Commands.RemoveProductDetail;
using Store.Application.Services.Products.Queries.GetAllCategories;
using Store.Application.Services.Products.Queries.GetCategories;
using Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Store.Application.Services.Products.Queries.GetProductForAdmin;
using Store.Application.Services.Queries.GetProductDetailForSite;
using Store.Application.Services.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
    public interface IProductFacad
    {
        IAddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        IEditProductService EditProductService { get; }
        IRemoveProductService RemoveProductService { get; }
        IAddNewProductService AddNewProductService { get; }
        //نمایش  همه محصولات درج شده در  قسمت لیست کشویی محصولات
        IGetAllCategoriesService GetAllCategoriesService { get; }
        //نمایش محصولات و نمایش جزییات محصولات در قسمت محصولات
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
        //نمایش محصولات در قسمت جستجو
        IGetCategoryService GetCategoryService { get; }

        //  نمایش لیست محصولات در ادمین
        IGetProductForAdminService GetProductForAdminService { get; }
        //نمایش جزییات محصولات 
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        //ویرایش محصول در قسمت لیست محصولات
        IEditeProductService EditeProductService { get; }
        //حذف محصول در قسمت یست محصولات
        IRemoveProductDetailService RemoveProductDetailService { get; }
    }
}