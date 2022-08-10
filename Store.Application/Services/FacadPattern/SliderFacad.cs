using Microsoft.AspNetCore.Hosting;
using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Common.Queries.GetAllSliderHomePage;
using Store.Application.Services.Common.Queries.GetSlider;
using Store.Application.Services.HomePage.AddNewSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.FacadPattern
{
   public class SliderFacad: ISliderFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public SliderFacad(IDataBaseContext context , IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        private IAddNewSliderService _addNewSliderService;
        public IAddNewSliderService AddNewSliderService {
            get
            {
                return _addNewSliderService = _addNewSliderService ?? new AddNewSliderService(_context,_environment);
            } 
        }
        private IGetSliderService _getSliderService;
        public IGetSliderService GetSliderService
        {
            get
            {
                return _getSliderService = _getSliderService ?? new GetSliderService(_context);
            }
        }
        private IGetAllHomePageSliderService _getAllHomePageSliderService;
        public IGetAllHomePageSliderService GetAllHomePageSliderService
        {
            get
            {
                return _getAllHomePageSliderService = _getAllHomePageSliderService ?? new GetAllHomePageSliderService(_context);
            }
        }
    }
}
