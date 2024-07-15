using EApp.Domain.Entities.Concrete;

namespace EAPP.API.Models.DTOs
{
    public class GetOrderDTO
    {
        public decimal TotalPrice { get; set; }
        public int AppUserId { get; set; }
    }
}
