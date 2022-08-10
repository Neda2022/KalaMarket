using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize("Admin,Operator")]
    public class OrdersController : Controller
    {
        private readonly ICartFacad _cartFacad;
        public OrdersController(ICartFacad cartFacad)
        {
            _cartFacad = cartFacad;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_cartFacad.GetOrdersAdminService.Execute(orderState).Data);
        }
    }
}
