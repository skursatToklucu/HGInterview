using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class UserRepository<T> : IUserRepository<T> where T : UserEntity
    {
        public bool Activate(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        public List<T> GetActive()
        {
            throw new NotImplementedException();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public T GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
