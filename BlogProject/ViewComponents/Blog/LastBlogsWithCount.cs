using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
    public class LastBlogsWithCount : ViewComponent
    {
        BlogManager blogManager = 
            new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetLastBlogsWithCount(3);
            return View(values);
        }
    }
}
