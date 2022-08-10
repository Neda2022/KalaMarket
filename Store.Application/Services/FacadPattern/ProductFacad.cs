using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
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

namespace Store.Application.Services.Products.FacadPattern
{
  public class ProductFacad:IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
        }
        private IAddNewCategoryService _addNewCategoryService;
        public IAddNewCategoryService AddNewCategoryService {
            
            get
            {

                return _addNewCategoryService = _addNewCategoryService ?? new AddNewCategoryService(_context);

            } 
        }
        private  IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService { 
            get {


                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private IEditProductService _editProductService;
        public IEditProductService EditProductService {
            get
            {
                return _editProductService = _editProductService ?? new EditProductService(_context);
            }
        }
        private IRemoveProductService _removeProductService;
        public IRemoveProductService RemoveProductService
        {
            get
            {
                return _removeProductService = _removeProductService ?? new RemoveProductService(_context);
            }
        }
       
        private IAddNewProductService _addNewProductService;
        public IAddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }
        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }
        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }
        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService
        {
            get
            {
                return _getCategoryService = _getCategoryService ?? new GetCategoryService(_context);
            }
        }
        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }
        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }
        private IEditeProductService _editeProductService;
        public IEditeProductService EditeProductService
        {
            get
            {
                return _editeProductService = _editeProductService ?? new EditeProductService(_context);
            }
        }
        private IRemoveProductDetailService _removeProductDetailService;
        public IRemoveProductDetailService RemoveProductDetailService
        {
            get
            {
                return _removeProductDetailService = _removeProductDetailService ?? new RemoveProductDetailService(_context);
            }
        }
    }

    }

