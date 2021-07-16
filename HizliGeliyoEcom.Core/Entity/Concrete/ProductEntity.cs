using HizliGeliyoEcom.Core.Entity.Abstract;
using HizliGeliyoEcom.Core.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HizliGeliyoEcom.Core.Entity.Concrete
{
    public class ProductEntity : IEntity<int>
    {

        public int ID { get; set; }

        public string Title { get; set; }


        public double Price { get; set; }

        public string Description { get; set; }


        public string Category { get; set; }


        public string Image { get; set; }

        public Status Status { get; set; }

    }
}
