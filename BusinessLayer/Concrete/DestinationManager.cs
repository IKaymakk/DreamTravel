using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _dal;
        private readonly Context _context;

        public DestinationManager(IDestinationDal dal)
        {
            _dal = dal;
        }

        public void Delete(Destination t)
        {
            _dal.Delete(t);
        }

        public Destination GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Destination> GetListAll()
        {
            return _dal.GetAll();
        }

        //public float GetTotalPrice()
        //{
        //    return (float)_context.Destinations.Sum(d => d.Price);
        //}

        public void Insert(Destination t)
        {
            _dal.Add(t);
        }

        public void Update(Destination t)
        {
            _dal.Update(t);
        }
    }
}
