using HizliGeliyoEcom.Core.Mapping;
using HizliGeliyoEcom.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Mapping
{
    public class ProductMap : ProductMap<Product>
    {

        public override void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.ID);



            base.Configure(builder);
        }
    }
}
