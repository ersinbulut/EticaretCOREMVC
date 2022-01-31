using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : IGenericDal<Comments>
    {
        public void Delete(Comments t)
        {
            throw new NotImplementedException();
        }

        public Comments GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comments> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Comments t)
        {
            throw new NotImplementedException();
        }

        public void Update(Comments t)
        {
            throw new NotImplementedException();
        }
    }
}
