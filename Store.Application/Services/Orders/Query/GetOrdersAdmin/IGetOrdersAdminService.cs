using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Query.GetOrdersAdmin
{
  public  interface IGetOrdersAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }

    public class GetOrdersAdminService : IGetOrdersAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                .Include(p => p.OrderDetails)
                .Where(p => p.OrderState == orderState)
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new OrdersDto
                {

                    OrderId = p.Id,
                    InsertTime = p.InsertTime,
                    OrderState = p.OrderState,
                    ProductCount = p.OrderDetails.Count(),
                    RequestId = p.RequestPayId,
                    UserId = p.UserId,

                }).ToList();

            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                Success = true,

            };
        }
    }
    public class OrdersDto
    {
        public long OrderId { get; set; }
        public DateTime InsertTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }
    }
}
