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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void Delete(ContactUs t)
        {
            throw new NotImplementedException();
        }

        public ContactUs GetById(int id)
        {
            return _contactUsDal.GetById(id);
        }

        public List<ContactUs> GetListAll()
        {
            return _contactUsDal.GetAll();
        }

        public void Insert(ContactUs t)
        {
            throw new NotImplementedException();
        }

        public void TChangeMessageStatus(int id)
        {
            var value = _contactUsDal.GetById(id);
            if (value.Status == true)
            {
                value.Status = false;
                _contactUsDal.Update(value);
            }
            else
            {
                value.Status = true;
                _contactUsDal.Update(value);
            }
        }

        public List<ContactUs> TFalseMessageList()
        {
            return _contactUsDal.FalseMessageList();
        }

        public List<ContactUs> TTrueMessageList()
        {
            return _contactUsDal.TrueMessageList();
        }

        public void Update(ContactUs t)
        {
            throw new NotImplementedException();
        }
    }
}
