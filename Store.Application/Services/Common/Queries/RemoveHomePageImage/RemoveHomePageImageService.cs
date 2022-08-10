using Microsoft.AspNetCore.Hosting;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System;

namespace Store.Application.Services.Common.Queries.RemoveHomePageImage
{
    public class RemoveHomePageImageService : IRemoveHomePageImageService
    {
        private readonly IDataBaseContext _context;
       private readonly IHostingEnvironment _environment;
        public RemoveHomePageImageService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;

        }
        public ResultDto Execute(long Id)
        {



            var images = _context.HomePageImages.Find(Id);
            if (images == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "عکس مورد نظر یافت نشد!"
                };

            }
                images.RemoveTime = DateTime.Now;
                images.IsRemoved = true;
                _context.SaveChanges();
                return new ResultDto()
                {
                    Success = true,
                    Message = "عکس با موفقیت حذف شد"
                };
           
           
        }
    }
}
