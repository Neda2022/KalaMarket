
using Store.Domain.Entities.HomePages;

namespace Store.Application.Services.Common.Queries.GetHomeImages
{
    public class HomePageImageDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
        


    }
}
