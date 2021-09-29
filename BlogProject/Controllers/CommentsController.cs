using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
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

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        //bir id parametresi alacaksin cunku bu id ile islem yapacagiz
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetAllByBlogId(id);
            return PartialView(values);
        }
    }
}
