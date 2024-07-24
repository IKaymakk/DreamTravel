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
    public class ReservationManager : IReservationService
    {
        IReservationDal _dal;

        public ReservationManager(IReservationDal dal)
        {
            _dal = dal;
        }

        public void Delete(Reservation t)
        {
            _dal.Delete(t);
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Reservation> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Reservation t)
        {
            _dal.Add(t);
        }

        public void Update(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
