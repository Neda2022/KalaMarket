using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entities.Orders
{
    public enum OrderState
    {
        [Display(Name ="سفارشات معلق")]
        Processing = 0,
        [Display(Name ="سفارشات لغو شده")]
        Canceled = 1,
        [Display(Name ="سفارشات تحویل داده شده")]
        Delivered = 2,
    }

}
