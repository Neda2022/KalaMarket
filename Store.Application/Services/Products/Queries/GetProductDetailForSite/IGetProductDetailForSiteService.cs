using Store.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Queries.GetProductDetailForSite
{
    public  interface IGetProductDetailForSiteService
    {

        ResultDto<ProductDetailForSiteDto> Execute(long Id);
    }
}
