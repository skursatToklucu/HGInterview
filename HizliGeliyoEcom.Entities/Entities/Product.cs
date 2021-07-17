using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Entities.Entities
{
    public class Product : SideEntity
    {

        public string Title { get; set; }


        public double Price { get; set; }

        public string Description { get; set; }


        public string Category { get; set; }


        public string Image { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
