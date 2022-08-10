using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Services.Products.Queries.GetAllCategories;
using Store.Common.Dto;

namespace Store.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }



}
