using System.Collections.Generic;

namespace Store.Application.Services.Common.Queries.GetAllSliderHomePage
{
    public class ResultSliderDto
    {
        public List<SliderDto> Slider { get; set; }
        public int TotalRow { get; set; }
    }
}
