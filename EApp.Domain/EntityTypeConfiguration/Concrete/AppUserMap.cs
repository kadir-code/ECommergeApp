using EApp.Domain.Entities.Concrete;
using EApp.Domain.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.EntityTypeConfiguration.Concrete
{
    public class AppUserMap : BaseEntityMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x=>x.AppRole).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.AppRoleId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
