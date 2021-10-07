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
            //var values = blogManager.GetAll();
            //blogun kategori bilgilerine de erismek istiyorum
            var values = blogManager.GetAllWithCategory(); //eager laoding
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }
    }
}
