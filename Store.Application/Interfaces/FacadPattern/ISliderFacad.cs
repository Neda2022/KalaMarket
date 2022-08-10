using Store.Application.Services.Common.Queries.GetAllSliderHomePage;
using Store.Application.Services.Common.Queries.GetSlider;
using Store.Application.Services.HomePage.AddNewSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
   public interface ISliderFacad
    {
        IAddNewSliderService AddNewSliderService { get; }
        IGetSliderService GetSliderService { get; }
        IGetAllHomePageSliderService GetAllHomePageSliderService { get; }
    }
}
