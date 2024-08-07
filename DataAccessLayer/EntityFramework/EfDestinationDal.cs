using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        private readonly Context _context;

        public EfDestinationDal(Context context)
        {
            _context = context;
        }

        public void ChangeDestinationStatus(int id)
        {
            var value = this.GetById(id);
            if (value != null)
            {
                if (value.Status == true)
                {
                    value.Status = false;
                }
                else
                {
                    value.Status = true;
                }
                this.Update(value);
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            var values = _context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
            return values;
        }

        public float GetTotalPrice()
        {
            return (float)_context.Reservations.Sum(r => r.Destination.Price);
        }

        public float GetTotalPriceCurrentMonth()
        {
            return (float)_context.Reservations.Where(x => x.ReservationDate.Month == DateTime.Now.Month).Sum(r => r.Destination.Price);
        }

        public float GetTotalPriceJanuary()
        {
            return (float)_context.Reservations.Where(x => x.ReservationDate.Month == 1).Sum(r => r.Destination.Price);
        }
    }
}
