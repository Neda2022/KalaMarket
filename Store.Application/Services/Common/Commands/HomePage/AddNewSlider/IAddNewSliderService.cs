using Microsoft.AspNetCore.Http;
using Store.Application.Services.Products.Commands.AddNewProduct;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePage.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile file, string link);
    }
}
