using Store.Common.Dto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetAllSliderHomePage
{
    public interface IGetAllHomePageSliderService
    {
        ResultDto<ResultSliderDto> Execute(int page, int pagesize);
    }
}
