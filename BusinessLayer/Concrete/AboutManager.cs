using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _dal;

        public AboutManager(IAboutDal dal)
        {
            _dal = dal;
        }

        public void Delete(About t)
        {
            _dal.Delete(t);
        }

        public About GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<About> GetListAll()
        {
            return _dal.GetAll();
        }

        public void Insert(About t)
        {
            _dal.Add(t);
        }

        public void Update(About t)
        {
            _dal.Update(t);
        }
    }
}
