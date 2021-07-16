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
    public class OrderDetailMap : SideMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails);

        }
    }
}
