using HizliGeliyoEcom.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.Core.Entity.Concrete
{
    public class UserEntity : IEntity<Guid>
    {
        public Guid ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
