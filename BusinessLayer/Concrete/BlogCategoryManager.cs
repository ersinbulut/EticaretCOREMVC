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
    public class BlogCategoryManager : IBlogCategoryService
	{
		IBlogCategoryDal _blogCategoryDal;

		public BlogCategoryManager(IBlogCategoryDal blogCategoryDal)
		{
			_blogCategoryDal = blogCategoryDal;
		}

        public BlogCategory GetById(int id)
        {
            return _blogCategoryDal.GetByID(id);
        }

        public List<BlogCategory> GetList()
        {
            return _blogCategoryDal.GetListAll();
        }

        public List<BlogCategory> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(BlogCategory t)
        {
            _blogCategoryDal.Insert(t);
        }

        public void TDelete(BlogCategory t)
        {
            _blogCategoryDal.Delete(t);
        }

        public void TUpdate(BlogCategory t)
        {
            _blogCategoryDal.Update(t);
        }
    }
}
