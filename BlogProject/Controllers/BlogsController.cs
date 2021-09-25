using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class BlogsController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        //Burasi bizim bloglari listeleyecegimiz yer olacak.
        public IActionResult Index()
        {
            var values = blogManager.GetAll();
            return View(values);
        }
    }
}
