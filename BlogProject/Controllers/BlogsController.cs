using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
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

        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetAllByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> category_values = (from x in categoryManager.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        //benim burada amacim:
                                                        //bloglari eklerken, bloglari sectigim zaman id degerinin gonderilmesi
                                                        //dropdown aracinda
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString()
                                                    }).ToList();
            ViewBag.categoryvalues = category_values;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.Status = true;
                blog.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                blogManager.Add(blog);

                return RedirectToAction("BlogListByWriter", "Blogs");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
