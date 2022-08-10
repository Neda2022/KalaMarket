using Store.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        ResultDto<ResultProductForSiteDto> Execute(Ordering ordering,string searchKey,int pageSize, int Page, long? CatId);
    }
    public enum Ordering
    {

        NotOrder = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروشترین
        /// </summary>
        Bestselling = 2,
        /// <summary>
        /// محبوبترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        /// جدیدترین
        /// </summary>
        theNewest = 4,
        /// <summary>
        /// ارزانترین
        /// </summary>
        Cheapest = 5,
        /// <summary>
        /// گرانترین
        /// </summary>
        theMostExpensive = 6
    }
}
