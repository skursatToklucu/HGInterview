using HizliGeliyoEcom.Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Core.Mapping
{
    public class CoreMap<T> : IEntityTypeConfiguration<T> where T : UserEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
        }
    }
}
