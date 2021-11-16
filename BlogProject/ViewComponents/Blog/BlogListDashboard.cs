using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(
            new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetLastBlogsWithCategoryByCount(10);
            return View(values);
        }
    }
}
