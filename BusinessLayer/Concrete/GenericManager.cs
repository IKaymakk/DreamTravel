using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, new()
    {
        private readonly IGenericDal<T> _genericdal;

        public GenericManager(IGenericDal<T> genericdal)
        {
            _genericdal = genericdal;
        }

        public void Delete(T t)
        {
            _genericdal.Delete(t);
        }

        public T GetById(int id)
        {
            return _genericdal.GetById(id);
        }

        public List<T> GetListAll()
        {
            return _genericdal.GetAll();
        }

        public void Insert(T t)
        {
            _genericdal.Add(t);
        }

        public void Update(T t)
        {
            _genericdal.Update(t);
        }
    }
}
