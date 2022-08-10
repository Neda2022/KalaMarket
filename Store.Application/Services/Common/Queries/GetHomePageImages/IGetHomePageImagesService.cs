using Store.Common.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        ResultDto<List<HomePageImagesDto>> Execute();
    }
}
