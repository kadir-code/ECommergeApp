namespace EAPP.API.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StockCode { get; set; }
    }
}
