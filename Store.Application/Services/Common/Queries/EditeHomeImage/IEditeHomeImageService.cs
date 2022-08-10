using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.EditeHomeImage
{
    public interface IEditeHomeImageService
    {
        ResultDto Execute(RequestHomePageDto request);
    }
}


