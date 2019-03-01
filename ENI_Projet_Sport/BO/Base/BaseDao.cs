using ENI_Projet_Sport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Base
{
    public class BaseDao<T> : IBaseDao<T> where T : class
    {
        private ApplicationDbContext _context { get; set; }
        public BaseDao()
        {
            _context = new ApplicationDbContext();
        }
        public bool Delete(T entity)
        {
            var success = false;
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            return success;
        }

        public List<T> GetAll()
        {
            List<T> result = null;

            result = _context.Set<T>().ToList();

            return result;
        }

        public T GetByID(int id)
        {
            T result = null;
            result = _context.Set<T>().Find(id);

            return result;
        }

        public bool Insert(T entity)
        {
            var success = false;
            if (entity != null)
            {
                _context.Set<T>().Add(entity);
                success = true;
            }

            return success;
        }

        public bool Update(T entity)
        {
            var success = false;

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                success = true;
            }

            return success;
        }

        public bool Commit()
        {
            var success = false;

            try
            {
                _context.SaveChanges();
                success = true;
            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }
    }
}
