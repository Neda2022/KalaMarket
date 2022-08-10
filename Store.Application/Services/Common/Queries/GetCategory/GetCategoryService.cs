using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Common.Queries.GetCategory
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _contex;

        public GetCategoryService(IDataBaseContext context)
        {
            _contex = context;

        }
        public ResultDto<List<CategoryDto>> Execute()
        {
            var category = _contex.Categories
                   .Where(p => p.ParentCategoryId == null)
                   .ToList()
                   .Select(p=> new CategoryDto { 
                   CatId=p.Id,
                   CategoryName=p.Name,
                   }).ToList();
            return new ResultDto<List<CategoryDto>>()
            {
                Data = category,
                Success = true,
            };
        }
    }
}
