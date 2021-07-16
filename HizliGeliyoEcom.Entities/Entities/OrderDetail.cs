using HizliGeliyoEcom.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Entities
{
    public class OrderDetail : SideEntity
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
