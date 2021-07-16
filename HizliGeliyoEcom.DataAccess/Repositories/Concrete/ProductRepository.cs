using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class ProductRepository<T> : IProductRepository<T> where T : ProductEntity
    {
        private readonly ProjectContext _context;

        public ProductRepository(ProjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gelen ID ye Ait Entitynin Status durumunu Active olarak değiştirip, update eder.
        /// </summary>
        /// <param name="id">Entitynin ID si</param>
        /// <returns></returns>
        public bool Activate(int id)
        {
            T activated = GetByID(id);
            activated.Status = Core.Enum.Status.Active;
            return Update(activated);
        }

        /// <summary>
        /// Gelen ID ye Ait Entitynin Status durumunu deactive olarak değiştirip, update eder.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeActivate(int id)
        {
            T deactivated = GetByID(id);
            deactivated.Status = Core.Enum.Status.Deactive;
            return Update(deactivated);
        }


        /// <summary>
        /// Gelen Entity'i Database'e ekler.
        /// </summary>
        /// <param name="item">Model Alır</param>
        /// <returns></returns>
        public bool Add(T item)
        {
            _context.Set<T>().Add(item);
            return Save() > 0;

        }

        /// <summary>
        /// Liste halinde modelleri database'e aktarır.
        /// </summary>
        /// <param name="items">Model alır</param>
        /// <returns></returns>
        public bool Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            return Save() > 0;
        }

        /// <summary>
        /// Sorguya göre veritabanında var mı yok mu diye kontrol eder. Bool döndürür.
        /// </summary>
        /// <param name="exp">Sorgu mesela (x => x.falanfilan)</param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);


        /// <summary>
        /// Databasede bulunan Statusü Active olan entityleri listeler
        /// </summary>
        /// <returns></returns>
        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status == Core.Enum.Status.Active).ToList();


        /// <summary>
        /// Ne var Ne yok getirir :)
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll() => _context.Set<T>().ToList();


        /// <summary>
        /// Sorguya göre Entityi döndürür.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();



        /// <summary>
        /// Databasede bulunan Statusü Active olan entityi dndürür. PieChart için method
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetByDefaultActive(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp => exp.Status == Core.Enum.Status.Active).FirstOrDefault();




        /// <summary>
        /// Sorguya göre Entitynin ID'sini döndürür.
        /// </summary>
        /// <param name="exp">Sorgu</param>
        /// <returns></returns>
        public int GetByDefaultOutID(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).Select(x => x.ID).FirstOrDefault();




        /// <summary>
        /// Gelen ID'ye göre o ID'ye ait Entity'i döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }


        /// <summary>
        /// Sorguya göre Liste döndürür Entity içerir.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        /// <summary>
        /// Gelen Entitynin Statusünü Deleted olarak değiştirir.Silinmiş gibi yapar.
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            item.Status = Core.Enum.Status.Deactive;
            return Update(item);
        }

        /// <summary>
        /// Gelen ID'yi göre Entitynin statusünü Deleted yapar. 
        /// Transaction :Birbirini izleyen işlemlerin herhangi birinde hata olması durumunda yapılan tüm işlemlerim geri alınmasını sağlar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T deleted = GetByID(id);
                    deleted.Status = Core.Enum.Status.Deactive;
                    ts.Complete();
                    return Update(deleted);
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Sorguya göre Hepsini Siler
        /// Transaction :Birbirini izleyen işlemlerin herhangi birinde hata olması durumunda yapılan tüm işlemlerim geri alınmasını sağlar.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp);
                    int count = 0;


                    foreach (var item in collection)
                    {
                        item.Status = Core.Enum.Status.Deactive;
                        bool opResult = Update(item);
                        if (opResult) count++;
                    }

                    if (collection.Count == count) ts.Complete();
                    else return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        /// <summary>
        /// Veritabanına kaydeder.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _context.SaveChanges();
        }


        /// <summary>
        /// Gelen Entityi Günceller
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;

            }
        }

        /// <summary>
        /// Liste halinde gelen entitileri toplu gunceller.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool UpdateRange(List<T> entities)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
