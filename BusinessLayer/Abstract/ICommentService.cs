﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        //List<Comment> GetAll(int id);
        List<Comment> GetAdminList();
        public List<Comment> TGetListCommentWithDestinationAndUser(int id);
    }
}
