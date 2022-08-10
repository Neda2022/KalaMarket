using Store.Common.Dto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        ResultDto<ProductDetailForAdminDto> Execute(long Id);

    }
   
    
}
