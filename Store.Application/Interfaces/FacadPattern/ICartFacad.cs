using Store.Application.Services;
using Store.Application.Services.Carts;
using Store.Application.Services.Finance.Commands.AddRequestPay;
using Store.Application.Services.Finance.Queries.GetRequestPayService;
using Store.Application.Services.Orders.Commands.AddNewOrder;
using Store.Application.Services.Orders.Query;
using Store.Application.Services.Orders.Query.GetOrdersAdmin;
using Store.Application.Services.Orders.Query.GetUserOrder;
using Store.Domain.Entities.Finances.Query.GetRequestPayForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
   public interface ICartFacad
    {
        ICartService CartService { get;}
        IAddRequestPayService AddRequestPayService { get; }
        IGetRequestPayService GetRequestPayService { get;  }
        IAddNewOrderService AddNewOrderService { get; }
        IGetUserOrdercsService GetUserOrdercsService { get; }
        IGetOrdersAdminService GetOrdersAdminService { get; }
        IGetRequestPayForAdminService GetRequestPayForAdminService { get; }
    }
}
