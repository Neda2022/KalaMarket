using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.RemoveHomePageImage
{
    public  interface IRemoveHomePageImageService
    {
        ResultDto Execute(long Id);
    }
}
