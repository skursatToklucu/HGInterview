using HizliGeliyoEcom.Core.Entity.Abstract;
using HizliGeliyoEcom.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Core.Entity.Concrete
{
    public class ProductEntity : IEntity<Guid>
    {
        public Guid ID { get; set; }

        public int ApiID { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; }

    }
}
