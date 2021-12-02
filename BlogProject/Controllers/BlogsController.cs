using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreLayer.Extensions;
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
    public class BlogsController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        //Burasi bizim bloglari listeleyecegimiz yer olacak.
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var values = blogManager.GetAll();
            //blogun kategori bilgilerine de erismek istiyorum
            var values = blogManager.GetAllWithCategory(); //eager laoding
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetAllWithCategoryByWriterId(User.GetId().Value);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
    
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
                blog.WriterId = User.GetId().Value;
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
        
        public IActionResult DeleteBlog(int id)
        {
            //silmek istedigimiz Blog entitysini bulalim
            var blog_value = blogManager.GetById(id);
            //ve veritabanindan silelim
            blogManager.Delete(blog_value);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            //sayfa yuklendigi zaman sen bana bi verileri getir
            var blogValue = blogManager.GetById(id);
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
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            //bir http post islemi oldugu zaman update islemi yap
            var blogToUpdate = blogManager.GetById(blog.BlogId);
            blogToUpdate.BlogImage = blog.BlogImage;
            blogToUpdate.CategoryID = blog.CategoryID;
            blogToUpdate.Content = blog.Content;
            blogToUpdate.Title = blog.Title;
            blogToUpdate.ThumbnailImage = blog.ThumbnailImage;
            blogManager.Update(blogToUpdate);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
