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

namespace Store.Application.Interfaces.FacadPattern
{
   public interface IAddHomeImageFacad
    {
         IAddHomeImageService AddHomeImageService { get; }
        IGetAllHomePageImagesService GetAllHomePageImagesService { get; }
        IGetHomePageImagesService GetHomePageImagesService { get; }
        IRemoveHomePageImageService RemoveHomePageImageService { get;  }
        IEditeHomeImageService EditeHomeImageService { get; }
    }
}
