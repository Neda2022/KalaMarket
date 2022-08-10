namespace Store.Application.Services.Products.Queries.GetCategories
{
    public class CategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public bool IsActive { get; set; }
        public ParentCategoryDto Parent { get; set; }

    }
}



