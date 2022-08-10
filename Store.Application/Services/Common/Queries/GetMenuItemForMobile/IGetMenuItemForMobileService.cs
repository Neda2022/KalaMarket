using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Application.Services.Common.Queries.GetMenuItem;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetMenuItemForMobile
{
    public interface IGetMenuItemForMobileService
    {
        ResultDto<List<MenuItemMobileDto>> Execute();
    }
    public class GetMenuItemForMobileService : IGetMenuItemForMobileService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemForMobileService(IDataBaseContext context)
        {
            _context = context;

        }
        public ResultDto<List<MenuItemMobileDto>> Execute()
        {
            var category = _context.Categories
                 .Include(p => p.SubCategories)
                 .Where(p => p.ParentCategory == null)
                 .Select(p => new MenuItemMobileDto
                 {
                     CatId = p.Id,
                     Name = p.Name,
                     
                     ParentId = p.ParentCategory.ParentCategoryId,
                     Child = p.SubCategories.ToList().Select(c => new MenuItemMobileDto
                     {
                        CatId=c.Id,
                        Name=c.Name,

                     }).ToList()

                 }).ToList();

            return new ResultDto<List<MenuItemMobileDto>>()
            {
                Data = category,
                Success = true,
            };
        }
    }



    public class MenuItemMobileDto
    {
        public long CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemMobileDto> Child { get; set; }
        public long? ParentId { get; set; }



    }
}
