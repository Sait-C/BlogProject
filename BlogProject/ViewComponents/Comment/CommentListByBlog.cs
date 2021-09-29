using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager commentManager = new CommentManager(
            new EfCommentRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetAllByBlogId(id);
            return View(values);
        }
    }
}
