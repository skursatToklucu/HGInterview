using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class ProductRepository<T> : IProductRepository<T> where T : ProductEntity
    {
        public bool Activate(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Add(List<T> items)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public List<T> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
