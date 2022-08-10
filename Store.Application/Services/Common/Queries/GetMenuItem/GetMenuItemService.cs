using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _context.Categories
                  .Include(p => p.SubCategories)
                  .Where(p => p.ParentCategory == null )
                  .Select(p => new MenuItemDto

                  {
                      
                      CatId = p.Id,
                      Name = p.Name,
                      
                      Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                      {
                          CatId = child.Id,
                          Name = child.Name,
                      } ).ToList(),
                      


                  }).ToList();
                



            return new ResultDto<List<MenuItemDto>>()
            {
                Data = category,
                Success = true,
            };
        }
    }

}
