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
	public class CommentManager : ICommentService
	{
		ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		

		

		

		public Comments GetById(int id)
		{
			return _commentDal.GetByID(id);
		}

		public List<Comments> GetList()
		{
			throw new NotImplementedException();
		}

		public void TAdd(Comments t)
		{

			_commentDal.Insert(t);
		}

		public void TDelete(Comments t)
		{

			_commentDal.Delete(t);
		}

		public void TUpdate(Comments t)
		{

			_commentDal.Update(t);
		}
	}
}
