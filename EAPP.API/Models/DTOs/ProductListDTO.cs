﻿namespace EAPP.API.Models.DTOs
{
    public class GetProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StockCode { get; set; }
        public int OrderId { get; set; }
    }
}
