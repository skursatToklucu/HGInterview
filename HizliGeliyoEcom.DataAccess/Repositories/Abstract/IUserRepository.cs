using HizliGeliyoEcom.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Abstract
{
    public interface IUserRepository<T> where T : UserEntity
    {
        bool Add(T item);

        bool Update(T item);

        T GetByID(Guid id);

        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetActive();

        List<T> GetDefault(Expression<Func<T, bool>> exp);

        bool Activate(Guid id);

        bool Any(Expression<Func<T, bool>> exp);

        int Save();
    }
}
