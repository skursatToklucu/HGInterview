using HizliGeliyoEcom.Core.Entity.Abstract;
using HizliGeliyoEcom.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Core.Entity.Concrete
{
    public class CoreEntity : IEntity<Guid>
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Status Status { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }
    }
}
