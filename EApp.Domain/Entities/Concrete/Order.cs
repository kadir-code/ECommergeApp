using EApp.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public ICollection<Product> Products { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
