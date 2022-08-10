using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePage.AddHomeImage
{
    public interface IAddHomeImageService
    {

        ResultDto Execute(RequestAddPageImageDto request);
    }

}
