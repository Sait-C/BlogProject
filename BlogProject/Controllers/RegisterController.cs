using BlogProject.Models;
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
    public class RegisterController : Controller
    {
        //Register/Index

        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        //Ekleme islemi yapilirken, HttpGet ve HttpPost attributelerinin 
        //tanimlandigi methodlarin isimleri ayni olmak zorunda

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p, RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            p.Status = true;
            p.About = "Test";
            writerManager.WriterAdd(p);
            //Redirect to main page after the action
            return RedirectToAction("Index", "Blogs");
        }
    }
}
