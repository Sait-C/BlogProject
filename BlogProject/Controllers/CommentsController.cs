using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class CommentsController : Controller
    {
        CommentManager commentManager = 
            new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        //PartialViewResult or IActionResult is response to do request of the end user
        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            p.BlogId = 9;
            commentManager.Add(p);
            return RedirectToAction("BlogDetails", "Blogs", new { id = p.BlogId });
        }

        //bir id parametresi alacaksin cunku bu id ile islem yapacagiz
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetAllByBlogId(id);
            return PartialView(values);
        }
    }
}
