using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Products;

namespace Store.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "نام دسته بندی را وارد کنید!",
                };
            }
            Category category = new Category()
            {
                Name = Name,
                ParentCategory= GetParent(ParentId),
               
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto()
            {
                Success = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
        }
        public Category GetParent(long? ParentId)
        {
            return _context.Categories.Find(ParentId);
        }
    }
}
