using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Controllers
{
    public class UserOrdersController : Controller
    {
        private readonly ICartFacad _cartFacad;
        public UserOrdersController(ICartFacad cartFacad)
        {
            _cartFacad = cartFacad;
        }
        public IActionResult Index()
        {
            long UserId = ClaimUtility.GetUserId(User).Value;
            return View(_cartFacad.GetUserOrdercsService.Execute(UserId).Data);
        }
    }
}
