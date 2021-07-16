using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.Core.Mapping;
using HizliGeliyoEcom.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Mapping
{
    public class OrderMap : SideMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
