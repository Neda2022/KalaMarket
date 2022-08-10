using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
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

namespace Store.Application.Services.FacadPattern
{
   public class CartFacad: ICartFacad
    {
        private readonly IDataBaseContext _context;
        public CartFacad(IDataBaseContext context)
        {
            _context = context;
        }
        private ICartService _cartService;
        public ICartService CartService
        {
            get
            {
                return _cartService = _cartService ?? new CartService(_context);
            }
        }
        private  IAddRequestPayService _addRequestPayService;
        public IAddRequestPayService AddRequestPayService
        {
            get
            {
                return _addRequestPayService = _addRequestPayService ?? new AddRequestPayService(_context);
            }
        }
        private IGetRequestPayService _getRequestPayService;
        public IGetRequestPayService GetRequestPayService
        {
            get
            {
                return _getRequestPayService = _getRequestPayService ?? new GetRequestPayService(_context);
            }
        }
        private IAddNewOrderService _addNewOrderService;
        public IAddNewOrderService AddNewOrderService
        {
            get
            {
                return _addNewOrderService = _addNewOrderService ?? new AddNewOrderService(_context);
            }
        }
        private IGetUserOrdercsService _getUserOrdercsService;
        public IGetUserOrdercsService GetUserOrdercsService
        {
            get
            {
                return _getUserOrdercsService = _getUserOrdercsService ?? new GetUserOrdercsService(_context);
            }
        }
        private IGetOrdersAdminService _getOrdersAdminService;
        public IGetOrdersAdminService GetOrdersAdminService
        {
            get
            {
                return _getOrdersAdminService = _getOrdersAdminService ?? new GetOrdersAdminService(_context);
            }

        }
        private IGetRequestPayForAdminService _getRequestPayForAdminService;
        public IGetRequestPayForAdminService GetRequestPayForAdminService
        {
            get
            {
                return _getRequestPayForAdminService = _getRequestPayForAdminService ?? new GetRequestPayForAdminService(_context);
            }

        }
    }
}
