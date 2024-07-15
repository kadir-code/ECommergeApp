using Microsoft.AspNetCore.Mvc.Rendering;

namespace EAPP.Web.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StockCode { get; set; }
        public int OrderId { get; set; }
        public SelectList? Orders { get; set; }

    }
}
