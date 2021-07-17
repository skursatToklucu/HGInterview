using HizliGeliyoEcom.Core.Entity.Abstract;
using HizliGeliyoEcom.Core.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HizliGeliyoEcom.Core.Entity.Concrete
{
    public class SideEntity : IEntity<int>
    {

        public int ID { get; set; }

        public Status Status { get; set; }

    }
}
