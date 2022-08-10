using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class Cart:ViewComponent
    {

        private readonly ICartFacad _cartFacad;
        private readonly CookiesManeger cookiesManeger;
        public Cart(ICartFacad cartFacad)
        {
            _cartFacad = cartFacad;
            cookiesManeger = new CookiesManeger();
        }
        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartFacad.CartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
