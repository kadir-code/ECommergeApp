using EApp.Domain.Entities.Concrete;
using EApp.Domain.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.EntityTypeConfiguration.Concrete
{
    public class ProductMap:BaseEntityMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.Products).HasForeignKey(x=>x.OrderId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
