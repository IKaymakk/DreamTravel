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
    public class SubAboutManager:ISubAboutService
    {
        ISubAboutDal _dal;

        public SubAboutManager(ISubAboutDal dal)
        {
            _dal = dal;
        }

        public void Delete(SubAbout t)
        {
            _dal.Delete(t);
        }

        public SubAbout GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<SubAbout> GetListAll()
        {
            return _dal.GetAll();
        }

        public void Insert(SubAbout t)
        {
            _dal.Add(t);
        }

        public void Update(SubAbout t)
        {
            _dal.Update(t);
        }
    }
}
