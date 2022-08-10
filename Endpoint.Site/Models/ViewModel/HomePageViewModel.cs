using Store.Application.Services.Common.Queries.GetHomeImages;
using Store.Application.Services.Common.Queries.GetHomePageImages;
using Store.Application.Services.Common.Queries.GetSlider;
using Store.Application.Services.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Models.ViewModel
{
   
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders{ get; set; }
        public List<HomePageImagesDto> PageImage { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> HomeTools { get; set; }
        public List<ProductForSiteDto> LapTop { get; set; }


    }
}

