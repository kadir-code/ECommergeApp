using EApp.Domain.Entities.Concrete;

namespace EAPP.API.Models.DTOs
{
    public class CreateOrderDTO
    {
        public decimal TotalPrice { get; set; }
        public int AppUserId { get; set; }
    }
}
