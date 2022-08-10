using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using System.Linq;

namespace Store.Application.Services.Common.Queries.GetHomeImages
{
    public partial class GetAllHomePageImagesService : IGetAllHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        public GetAllHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultHomeImages> Execute(int page, int pageSize)
        {
            int totalRow = 0;
            var imageQuery = _context.HomePageImages
                .AsQueryable();
            
            var image = imageQuery.ToPaged(page, pageSize, out totalRow);
            return new ResultDto<ResultHomeImages>()
            {

                Data = new ResultHomeImages
                {
                    TotalRow = totalRow,
                    HomeImages = image.Select(p => new HomePageImageDto
                    {
                        Id = p.Id,
                        Src=p.Src,
                        ImageLocation=p.ImageLocation,
                        Link=p.link,
                       
                    }).ToList(),
                },
                Success = true,
                
            };

        }
    }
}
