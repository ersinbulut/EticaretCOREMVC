using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreEticaret.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());

		[HttpGet]
		public PartialViewResult CommentAddPartial(int id)
		{
			var product = commentManager.GetById(id);
			return PartialView(product);
		}
		
		[HttpPost]
		public PartialViewResult CommentAddPartial(Comment comment)
		{
			comment.Name = "Batuhan";
			comment.AddedDate =DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.IsApproved = true;
			comment.Status = true;
			comment.ProductId = 3;
			commentManager.TAdd(comment);
			return PartialView();
		}

		public PartialViewResult CommentListByProduct(int id)
		{
			var values = commentManager.GetList(id);

			return PartialView(values);
		}
	}
}
