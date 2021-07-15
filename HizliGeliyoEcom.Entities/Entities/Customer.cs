using HizliGeliyoEcom.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Entities
{
    public class Customer : UserEntity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
