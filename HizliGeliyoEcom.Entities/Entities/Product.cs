using HizliGeliyoEcom.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Entities
{
    public class Product : ProductEntity
    {
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
