using HizliGeliyoEcom.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Core.Entity.Concrete
{
    public class SideEntity : IEntity<int>
    {
        public int ID { get; set; }
    }
}
