using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RequestPayController : Controller
    {
        private readonly ICartFacad _caradFacad;
        public RequestPayController(ICartFacad cartFacad)
        {
            _caradFacad = cartFacad;
        }
        public IActionResult Index(int page=1, int pageSize=10)
        {
            return View(_caradFacad.GetRequestPayForAdminService.Execute(page,pageSize).Data);
        }
    }
}
