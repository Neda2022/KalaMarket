using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using System.Linq;

namespace Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;

        }
        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(p => p.Category)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(p => new ProductsFormAdminList_Dto
                {
                    Id=p.Id,
                    Brand=p.Brand,
                    Category=p.Category.Name,
                    Description=p.Description,
                    Displayed=p.Displayed,
                    Name=p.Name,
                    Inventory=p.Inventory,
                    Price=p.Price,

                }).ToList();
            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto
                {
                    Products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount,
                },
                Success = true,
                Message = "",

            };
        }
    }
}
