using Store.Application.Interfaces.Context;
using System.Collections.Generic;
using System.Linq;
using Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Store.Application.Services.Products.Queries.GetAllCategories
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                   
                }
                ).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                Success = false,
                Message = "",
            };
        }
    }



}
