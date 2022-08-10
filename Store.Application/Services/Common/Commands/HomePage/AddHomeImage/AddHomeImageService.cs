using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.HomePages;
using System;
using System.IO;

namespace Store.Application.Services.HomePage.AddHomeImage
{
    public class AddHomeImageService : IAddHomeImageService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomeImageService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;

        }
        public ResultDto Execute(RequestAddPageImageDto request)
        {

            var resultUpload = UploadFile(request.file);

            HomePageImages homePageImages = new HomePageImages()
            {
                link = request.Link,
                Src = resultUpload.FileNameAddress,
                ImageLocation = request.ImageLocation,
            };
            _context.HomePageImages.Add(homePageImages);
            _context.SaveChanges();
            return new ResultDto()
            {
                Success = true,
            };
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
    public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }
        }
   

}
