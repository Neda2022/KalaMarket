using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Finances.Query.GetRequestPayForAdmin
{
   public interface IGetRequestPayForAdminService
    {
        ResultDto<ResultRequestPayDto> Execute(int page, int pageSize);
    }
    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int page, int pageSize)
        {
            var totalrow = 0;
            var requestPay = _context.RequestPays.Include(p => p.User).AsQueryable();
         
            var request = requestPay.ToPaged(page,pageSize,out totalrow);
            return new ResultDto<ResultRequestPayDto>()
            {

                Data = new ResultRequestPayDto
                {
                    TotalRow = totalrow,
                    RequestPayDto = request.Select(p=> new RequestPayDto {
                        Id = p.Id,
                        Amount = p.Amount,
                        Authority = p.Authority,
                        Guid = p.Guid,
                        IsPay = p.IsPay,
                        PayDate = p.PayDate,
                        RefId = p.RefId,
                        UserId = p.UserId,
                        UserName = p.User.FullName,

                    }).ToList(),

                },
                Success = true,
            };
        }
    }
    public class RequestPayDto
    {

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
       

    }
    public class ResultRequestPayDto
    {
        public int TotalRow { get; set; }
        public List<RequestPayDto> RequestPayDto { get; set; }
    }
}
