using BlogProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

        //RegisterViewModel içerisinde ConfirmPassword ve Password alanlari için validation var.
        //Formdaki bilgiler(ConfirmPassword ve Password input degerleri bu alanlara map ediliyor.
        //Validation bu degerler icin calisiyor ve eger validation gecersiz olursa
        //ViewModelState.IsValid = False oluyor.Index.cshtml'de bu map islemi icin
        //Ve validation gecersizlik message(ErrorMessage) yi o fieldin hemen altinda 
        //gostermek icin TagHelpers kullandik.Boylecek is valid false oldugunda
        //View tekrar yuklenir ama bu sefer ErrorMessageleri de gosterir

        [HttpPost]
        public IActionResult Index(Writer p, RegisterViewModel registerViewModel)
        {
            //Confirm Passsword
            if(!ModelState.IsValid)
            {
                return View();
            }

            //Validate Writer
            WriterValidator writerValidator = new WriterValidator();
            //Hangi degerleri validate edeceksin,
            //parametre olarak gonderilen Writeri validate edeceksin
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid) //eger sonuclar gecerliyse
            {
                p.Status = true;
                p.About = "Test";
                writerManager.WriterAdd(p);
                //Redirect to main page after the action
                return RedirectToAction("Index", "Blogs");
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
