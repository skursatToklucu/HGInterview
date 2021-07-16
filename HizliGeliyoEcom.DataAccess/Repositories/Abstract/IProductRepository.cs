using HizliGeliyoEcom.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Abstract
{
    public interface IProductRepository<T> where T : ProductEntity
    {
        bool Add(T item);

        bool Add(List<T> items);

        bool Update(T item);

        bool Remove(T item);

        bool Remove(int id);

        bool RemoveAll(Expression<Func<T, bool>> exp);

        T GetByID(int id);

        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetActive();

        List<T> GetDefault(Expression<Func<T, bool>> exp);

        List<T> GetAll();

        bool Activate(int id);

        bool Any(Expression<Func<T, bool>> exp);

        int Save();
    }
}
