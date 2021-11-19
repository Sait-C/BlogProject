﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EfBlogRepository());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            
            ViewBag.TotalNumberOfBlogs = blogManager.GetAll().Count();
            ViewBag.TotalNumberOfCategories = categoryManager.GetAll().Count();
            ViewBag.TotalNumberOfBlogsOfWriter = blogManager.GetAllByWriter(1).Count();

            return View();
        }
    }
}
