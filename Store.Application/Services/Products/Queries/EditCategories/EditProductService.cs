using Store.Application.Interfaces.Context;
using Store.Common.Dto;

namespace Store.Application.Services.Products.Commands.EditProduct
{
    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext _context;
        public EditProductService(IDataBaseContext context)
        {
            _context = context;

        }
        public ResultDto Execute(RequestEditProductDto request)
        {
            var product = _context.Categories.Find(request.Id);
            if (product == null)
            {
                return new ResultDto
                {
                    Success = false,
                    Message = "محصولی یافت نشد!"
                };
            }
            product.Name = request.Name;
            _context.SaveChanges();
            return new ResultDto
            {
                Success = true,
                Message = "ویرایش با موفقیت انجام شد!"
            };
        }
    }
}
