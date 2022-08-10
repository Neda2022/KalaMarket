using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetSlider
{
    public  interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();

    }
}
