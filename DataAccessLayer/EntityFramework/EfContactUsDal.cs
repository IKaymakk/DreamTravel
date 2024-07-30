﻿using DataAccessLayer.Abstract;
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
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ChangeMessageStatus(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> FalseMessageList()
        {
            using (var context = new Context())
            {
                return context.ContactUss.Where(x => x.Status == false).ToList();
            }
        }

        public List<ContactUs> TrueMessageList()
        {

            using (var context = new Context())
            {
                return context.ContactUss.Where(x => x.Status == true).ToList();
            }
        }

    }
}
