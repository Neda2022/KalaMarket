using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using System.Linq;

namespace Store.Application.Services.Common.Queries.GetAllSliderHomePage
{
    public class GetAllHomePageSliderService : IGetAllHomePageSliderService
    {
        private readonly IDataBaseContext _context;
        public GetAllHomePageSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultSliderDto> Execute(int page, int pagesize)
        {
            int totalRow = 0;
            var sliders = _context.Sliders.AsQueryable();
            var sliderQuery = sliders.ToPaged(page, pagesize, out totalRow);
            return new ResultDto<ResultSliderDto>
            {
                Data = new ResultSliderDto
                {
                    TotalRow = totalRow,
                    Slider = sliderQuery.Select(p => new SliderDto
                    {
                        Id = p.Id,
                        Link = p.link,
                        Src = p.Src,
                    }).ToList(),

                },
                Success = true,
            };
           
        }
    }
}
