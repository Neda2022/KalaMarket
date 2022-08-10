using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Queries.GetProductDetailForSite
{
    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForSiteDto> Execute(long Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .Where(p => p.Id == Id).FirstOrDefault();
            if (product == null)
            {
                throw new Exception("Product Not Found.....");
            }
            product.ViewCount++;
            _context.SaveChanges();


            return new ResultDto<ProductDetailForSiteDto>()
            {
                Data = new ProductDetailForSiteDto
                {
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory.Name}  - {product.Category.Name}",
                    Description = product.Description,
                    Id = product.Id,
                    Price = product.Price,
                    Title = product.Name,
                    Images = product.ProductImages.Select(p => p.Src).ToList(),
                    Features = product.ProductFeatures.Select(p => new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),

                },
                Success = true,
            };

        }

        
    }

}