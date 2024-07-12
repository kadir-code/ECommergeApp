namespace EAPP.API.Models.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StockCode { get; set; }
    }
}
