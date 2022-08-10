using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Common.Queries.GetHomePageImages
{
    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImagesDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImagesDto
                {
                    Id = p.Id,
                    ImageLocation = p.ImageLocation,
                    Link = p.link,
                    Src = p.Src,
                }).ToList();
            return new ResultDto<List<HomePageImagesDto>>()
            {
                Data = images,
                Success = true,
            };
        }
    }
}
