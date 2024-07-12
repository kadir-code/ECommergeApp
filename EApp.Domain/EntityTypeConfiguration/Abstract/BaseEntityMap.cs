using EApp.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.EntityTypeConfiguration.Abstract
{
    public class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T:BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CreateDate).IsRequired(false);
            builder.Property(x=>x.ModifiedDate).IsRequired(false);
            builder.Property(x=>x.RemovedDate).IsRequired(false);
            builder.Property(x=>x.Status).IsRequired(true);
        }
    }
}
