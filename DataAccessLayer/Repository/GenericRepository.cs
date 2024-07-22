using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Add(T t)
        {
            _object.Add(t);
            c.SaveChanges();
        }

        public void Delete(T t)
        {
            _object.Remove(t); c.SaveChanges();

        }

        public List<T> GetAll()
        {
            return _object.ToList(); c.SaveChanges();

        }

        public List<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); c.SaveChanges();

        }

        public T GetById(int id)
        {
            return _object.Find(id); c.SaveChanges();

        }

        public void Update(T t)
        {
            _object.Update(t); c.SaveChanges();

        }
    }
}
