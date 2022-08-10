using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetCategory
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoryDto>> Execute();
    }
}
