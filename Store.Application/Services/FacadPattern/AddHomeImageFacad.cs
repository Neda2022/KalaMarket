using Microsoft.AspNetCore.Hosting;
using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Common.Queries.EditeHomeImage;
using Store.Application.Services.Common.Queries.GetHomeImages;
using Store.Application.Services.Common.Queries.GetHomePageImages;
using Store.Application.Services.Common.Queries.RemoveHomePageImage;
using Store.Application.Services.HomePage.AddHomeImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.FacadPattern
{
   public class AddHomeImageFacad: IAddHomeImageFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomeImageFacad(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }
        private IAddHomeImageService _addHomeImageService;
        public IAddHomeImageService AddHomeImageService
        {
            get
            {
                return _addHomeImageService = _addHomeImageService ?? new AddHomeImageService(_context, _environment);
            }
        }
        private IGetAllHomePageImagesService _getAllHomePageImagesService;
        public IGetAllHomePageImagesService GetAllHomePageImagesService
        {
            get
            {
                return _getAllHomePageImagesService = _getAllHomePageImagesService ?? new GetAllHomePageImagesService(_context);
            }
        }
        private IGetHomePageImagesService _getHomePageImagesService;
        public IGetHomePageImagesService GetHomePageImagesService
        {
            get
            {
                return _getHomePageImagesService = _getHomePageImagesService ?? new GetHomePageImagesService(_context);
            }
        }

        private IRemoveHomePageImageService _removeHomePageImageService;
        public IRemoveHomePageImageService RemoveHomePageImageService
        {
            get
            {
                return _removeHomePageImageService = _removeHomePageImageService ?? new RemoveHomePageImageService(_context, _environment);
            }
        }
        private IEditeHomeImageService _editeHomeImageService;
        public IEditeHomeImageService EditeHomeImageService
        {
            get
            {
                return _editeHomeImageService = _editeHomeImageService ?? new EditeHomeImageService(_context);
            }
        }
    }
}
