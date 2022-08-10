using Store.Common.Dto;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }

    public class AddNewProduct_Features
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
