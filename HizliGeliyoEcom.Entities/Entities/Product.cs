using HizliGeliyoEcom.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Entities
{
    public class Product : ProductEntity
    {
        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
