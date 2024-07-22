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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _dal;

        public TestimonialManager(ITestimonialDal dal)
        {
            _dal = dal;
        }

        public void Delete(Testimonial t)
        {
            _dal.Delete(t);
        }

        public Testimonial GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Testimonial> GetListAll()
        {
            return _dal.GetAll();

        }

        public void Insert(Testimonial t)
        {
            _dal.Add(t);
        }

        public void Update(Testimonial t)
        {
            _dal.Update(t);
        }
    }
}
