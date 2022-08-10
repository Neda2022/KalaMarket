using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;

namespace Store.Application.Services.Products.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDataBaseContext _context;
        public RemoveProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var product = _context.Categories.Find(Id);
            if (product == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "محصولی یافت نشد!"
                };
            }
            product.RemoveTime = DateTime.Now;
            product.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto
            {
                Success = true,
                Message = "محصول باموفقیت حذف شد!"
            };
        }
    }
}
