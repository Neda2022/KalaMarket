using Microsoft.AspNetCore.Http;
using Store.Domain.Entities.HomePages;

namespace Store.Application.Services.HomePage.AddHomeImage
{
    public class RequestAddPageImageDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }



    }

}
