using Dto.Payment;
using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Orders.Commands.AddNewOrder;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using ZarinPal.Class;

namespace Endpoint.Site.Controllers
{
    //فقط کاربرانی که لاگین کردند اجازه ورود به پرداخت را داشته باشند
    [Authorize]
    public class PayController : Controller
    {
        private readonly ICartFacad _cartFacad;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public PayController(ICartFacad cartFacad)
        {
            _cartFacad = cartFacad;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index()
        {
            //گرفتن سبد خرید همراه با شناسایی کاربر
            long? userId = ClaimUtility.GetUserId(User);
            var cart = _cartFacad.CartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId);
            //ثبت اطلاعات خرید + مشخصات کاربر در دیتابیس
            if (cart.Data.SumAmount > 0)
            {

                var requestPay = _cartFacad.AddRequestPayService.Execute(cart.Data.SumAmount, userId.Value);
                //ارسال به درگاه بانک
                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = $"https://localhost:44366/Pay/Verify?guid={requestPay.Data.guid}",
                    Description = "پرداخت فاکتور شماره " + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");

            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }


        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {

            var requestPay = _cartFacad.GetRequestPayService.Execute(guid);
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);



            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartFacad.CartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            if (verification.Status == 100)
            {
                _cartFacad.AddNewOrderService.Execute(new RequestAddNewOrderSericeDto
                {
                    CartId = cart.Data.CartId,
                    UserId = UserId.Value,
                    RequestPayId = requestPay.Data.Id
                });

                //redirect to orders
                return RedirectToAction("Index", "UserOrders");
            }
            else
            {

            }

            return View();
        }
    }
    }
   

    

