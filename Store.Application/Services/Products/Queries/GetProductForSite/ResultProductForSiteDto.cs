using System.Collections.Generic;

namespace Store.Application.Services.Queries.GetProductForSite
{
    public class ResultProductForSiteDto
    {
        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }
}
