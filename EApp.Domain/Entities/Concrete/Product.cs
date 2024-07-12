using EApp.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.Entities.Concrete
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StockCode { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
