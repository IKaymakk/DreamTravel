using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _dal;

        public CommentManager(ICommentDal dal)
        {
            _dal = dal;
        }

        public void Delete(Comment t)
        {
            _dal.Delete(t);
        }

        public List<Comment> GetAll(int id)
        {
            return _dal.GetAllByFilter(x => x.DestinationID == id);
        }

        public Comment GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Comment> GetListAll()
        {
            return _dal.GetAll();
        }

        public void Insert(Comment t)
        {
            _dal.Add(t);
        }

        public void Update(Comment t)
        {
            _dal.Update(t);
        }
    }
}
