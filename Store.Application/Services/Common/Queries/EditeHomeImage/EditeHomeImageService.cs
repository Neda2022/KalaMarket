using Store.Application.Interfaces.Context;
using Store.Common.Dto;

namespace Store.Application.Services.Common.Queries.EditeHomeImage
{
    public class EditeHomeImageService: IEditeHomeImageService
    {
        private readonly IDataBaseContext _context;
        
        public EditeHomeImageService(IDataBaseContext context)
        {
            context = _context;

        }

        public ResultDto Execute(RequestHomePageDto request)
        {
            var imageHome = _context.HomePageImages.Find(request.Id);
            if (imageHome == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "لینک یافت نشد"
                };
            }
            imageHome.link = request.Link;
            _context.SaveChanges();
            return new ResultDto
            {
              Success=true,
             Message="لینک با موفقیت ذخیره شد"
            };
        }
    }
}


