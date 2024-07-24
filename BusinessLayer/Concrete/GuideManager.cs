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
    public class GuideManager : IGuideService
    {
        IGuideDal _dal;

        public GuideManager(IGuideDal dal)
        {
            _dal = dal;
        }

        public void Delete(Guide t)
        {
            _dal.Delete(t);
        }

        public Guide GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Guide> GetListAll()
        {
            return _dal.GetAll();
        }

        public void Insert(Guide t)
        {
            _dal.Add(t);
        }

        public void Update(Guide t)
        {
            _dal.Update(t);
        }
    }
}
