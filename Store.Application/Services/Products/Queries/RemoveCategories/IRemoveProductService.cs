using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(long Id);
    }
}
