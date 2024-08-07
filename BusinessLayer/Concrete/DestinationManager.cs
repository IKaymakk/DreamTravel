using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _dal;
        private readonly Context _context;

        public DestinationManager(IDestinationDal dal, Context context)
        {
            _dal = dal;
            _context = context;
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
        public void Insert(Destination t)
        {
            _dal.Add(t);
        }

        public void Update(Destination t)
        {
            _dal.Update(t);
        }

        public void ChangeDestinationStatus(int id)
        {
            _dal.ChangeDestinationStatus(id);
        }

        public float GetTotalPrice()
        {
            return _dal.GetTotalPrice();
        }

        public float GetTotalPriceCurrentMonth()
        {
            return _dal.GetTotalPriceCurrentMonth();
        }

        public float GetTotalPriceJanuary()
        {
            return _dal.GetTotalPriceJanuary();
        }

        public List<Destination> TGetLast4Destinations()
        {
            return _dal.GetLast4Destinations();
        }
    }
}
