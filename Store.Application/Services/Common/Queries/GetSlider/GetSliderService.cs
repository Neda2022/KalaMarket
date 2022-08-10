using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Common.Queries.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context = context;

        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var slider = _context.Sliders.OrderByDescending(p => p.Id).ToList()
                 .Select(p => new SliderDto
                 {
                     Link=p.link,
                     Src=p.Src,
                 }).ToList();
            return new  ResultDto<List<SliderDto>>(){

                Data=slider,
                Success=true,
            };
        }
    }
}
