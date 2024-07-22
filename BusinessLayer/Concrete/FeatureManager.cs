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
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _dal;

        public FeatureManager(IFeatureDal dal)
        {
            _dal = dal;
        }

        public void Delete(Feature t)
        {
            _dal.Delete(t);
        }

        public Feature GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Feature> GetListAll()
        {
            return _dal.GetAll();
        }

        public void Insert(Feature t)
        {
            _dal.Add(t);
        }

        public void Update(Feature t)
        {
            _dal.Update(t);
        }
    }
}
