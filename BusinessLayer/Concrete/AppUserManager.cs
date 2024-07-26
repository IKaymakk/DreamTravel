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
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Delete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser GetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> GetListAll()
        {
            return _appUserDal.GetAll();
        }

        public void Insert(AppUser t)
        {
            _appUserDal.Add(t);
        }

        public void Update(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}
