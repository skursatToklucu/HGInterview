using HizliGeliyoEcom.Core.Mapping;
using HizliGeliyoEcom.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Mapping
{
    public class CustomerMap : CoreMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);


            base.Configure(builder);
        }
    }
}
