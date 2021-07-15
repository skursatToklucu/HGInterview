using HizliGeliyoEcom.Core.Mapping;
using HizliGeliyoEcom.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Mapping
{
    public class ProductMap : SideMap<Product>
    {

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Customer).WithMany(x => x.Products).HasForeignKey(x => x.CustomerID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);


            base.Configure(builder);
        }
    }
}
