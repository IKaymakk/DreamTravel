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
            var value = _dal.GetById(id);
            if (value.Status == true)
            {
                value.Status = false;
                _dal.Update(value);
            }
            else
            {
                value.Status = true;
                _dal.Update(value);
            }
        }

        public float GetTotalPrice()
        {
            return (float)_context.Reservations
                .Where(r => r.Destination.Status == true) // Sadece aktif olan destinasyonlar
                .Sum(r => r.Destination.Price); // Her rezervasyonun destinasyon fiyatını toplar
        }
    }
}
