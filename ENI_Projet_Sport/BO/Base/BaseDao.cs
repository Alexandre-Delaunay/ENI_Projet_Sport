using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BO.Base
{
    public class BaseDao<T> : IBaseDao<T> where T : class
    {
        public BaseDao()
        {
            
        }
        public bool Delete(T entity)
        {
            var success = false;
            if (entity != null)
            {
                //ApplicationDbContextSingleton.ContextInstance.Entry(entity).State = EntityState.Deleted;
                ApplicationDbContextSingleton.ContextInstance.Set<T>().Remove(entity);
            }

            return success;
        }

        public List<T> GetAll()
        {
            List<T> result = null;

            result = ApplicationDbContextSingleton.ContextInstance.Set<T>().ToList();

            return result;
        }

        public T GetByID(int id)
        {
            T result = null;
            result = ApplicationDbContextSingleton.ContextInstance.Set<T>().Find(id);

            return result;
        }

        public bool Insert(T entity)
        {
            var success = false;
            if (entity != null)
            {
                ApplicationDbContextSingleton.ContextInstance.Set<T>().Add(entity);
                success = true;
            }

            return success;
        }

        public bool Update(T entity)
        {
            var success = false;

            if (entity != null)
            {
                //ApplicationDbContextSingleton.ContextInstance.Entry(entity).State = EntityState.Modified;
                ApplicationDbContextSingleton.ContextInstance.Set<T>().AddOrUpdate(entity);
                success = true;
            }

            return success;
        }

        public bool Commit()
        {
            var success = false;

            try
            {
                ApplicationDbContextSingleton.ContextInstance.SaveChanges();
                success = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return success;
        }
    }
}
