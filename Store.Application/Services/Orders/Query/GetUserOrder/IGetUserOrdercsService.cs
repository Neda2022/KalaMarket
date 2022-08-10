using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Query.GetUserOrder
{
   public interface IGetUserOrdercsService
    {
        ResultDto<List<GetUserOrderDto>> Execute(long UserId);
    }
    public class GetUserOrdercsService: IGetUserOrdercsService
    {
        private readonly IDataBaseContext _context;
        public GetUserOrdercsService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetUserOrderDto>> Execute(long UserId)
        {

            var orders = _context.Orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new GetUserOrderDto {
                    OrderId = p.Id,
                    orderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailDto {

                        Count=o.Count,
                        OrderDetailId=o.Id,
                        Price=o.Price,
                        ProductId=o.ProductId,
                        ProductName=o.Product.Name,


                    }).ToList(),

                }).ToList();
            
            return new ResultDto<List<GetUserOrderDto>>()
            {
                Data = orders,
                Success=true,
            };
        }
    }

    public class GetUserOrderDto
    {
        public long OrderId { get; set; }
        public OrderState orderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }

    public class OrderDetailDto
    {
        public long  OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }

        public int Price { get; set; }
        public int Count { get; set; }


    }

}

