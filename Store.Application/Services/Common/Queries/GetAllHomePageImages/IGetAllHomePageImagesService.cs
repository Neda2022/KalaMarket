using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Store.Application.Services.Common.Queries.GetHomeImages.GetAllHomePageImagesService;

namespace Store.Application.Services.Common.Queries.GetHomeImages
{
    public interface IGetAllHomePageImagesService
    {
        ResultDto<ResultHomeImages> Execute(int page, int pageSize);
    }
}
