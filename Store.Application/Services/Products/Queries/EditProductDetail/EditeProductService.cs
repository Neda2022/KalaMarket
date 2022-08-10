using Store.Application.Interfaces.Context;
using Store.Common.Dto;

namespace Store.Application.Services.Products.Commands.EditeProduct
{
    public class EditeProductService : IEditeProductService
    {
        private readonly IDataBaseContext _context;

        public EditeProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditProductDto request)
        {
            var product = _context.Products.Find(request.Id);
            if(product == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "محصولی یافت نشد!"
                };
            }
            product.Name = request.Name;
            product.Brand = request.Brand;
            product.Description = request.Description;
            product.Displayed = request.Displayed;
            product.Price = request.Price;
            product.Inventory = request.Inventory;
            _context.SaveChanges();
            return new ResultDto
            {
                Success = true,
                Message = "ویرایش با موفقیت انجام شد!"
            };

        }
    }
}
