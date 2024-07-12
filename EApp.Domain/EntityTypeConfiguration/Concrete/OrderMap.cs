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
    public class OrderMap:BaseEntityMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x=>x.AppUser).WithMany(x=>x.Orders).HasForeignKey(x=>x.AppUserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
