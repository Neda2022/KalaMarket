using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartFacad _cartFacad;
        private readonly CookiesManeger cookiesManeger ;

        public CartController(ICartFacad cartService)
        {
            _cartFacad = cartService;
            cookiesManeger = new CookiesManeger();
        }

        public IActionResult Index()
        {
           var userId=  ClaimUtility.GetUserId(User);

           var resultGetLst= _cartFacad.CartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext), userId);

            return View(resultGetLst.Data);
        }

        public IActionResult AddToCart(long ProductId)
        {
           

           var resultAdd= _cartFacad.CartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));

            return RedirectToAction("Index");
        }


        public IActionResult Add(long CartItemId)
        {
            _cartFacad.CartService.Add(CartItemId);
            return RedirectToAction("Index");
        }  
        
        public IActionResult LowOff(long CartItemId)
        {
            _cartFacad.CartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long ProductId)
        {
            _cartFacad.CartService.RemoveFromCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");

        }
    }
}
