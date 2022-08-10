using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.RemoveProductDetail
{
   public interface IRemoveProductDetailService
    {
        ResultDto Execute(long Id);
    }
    public class RemoveProductDetailService : IRemoveProductDetailService
    {
        private readonly IDataBaseContext _context;

        public RemoveProductDetailService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long Id)
        {
            var product = _context.Products.Find(Id);
            if (product == null)
            {
                return new ResultDto
                {
                    Message="محصولی یاف نشد.",
                    Success=false,
                    

                };

            }
            product.IsRemoved = true;
            product.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                Message = "محصول با موفقیت حذف شد.",
                Success = true
            };
        }
    }
}
