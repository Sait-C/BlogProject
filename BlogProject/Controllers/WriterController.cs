using BlogProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreLayer.Extensions;
using CoreLayer.Utilities.Helpers;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    /*Authorize Attribute: Yetkilendirme alanları olarak düşünebilirsiniz.
     * Yetkisiz erişimlerin veya sisteme authenticate olmamış, 
     * yani sisteme kullanıcı adi ve şifreyle giriş yapmamış kişilerin 
     * erişimini engellemek için kullanılan bir attributedir.*/
    //[Authorize] Controller seviyesinde authorize
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        //[Authorize] sadece bu sayfa icin gecerli olur
        public IActionResult Index()
        {
            ViewBag.Email = User.GetEmail();
            ViewBag.FullName = User.GetFullName();
            ViewBag.UserId = User.GetId();
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = writerManager.GetById(User.GetId().Value);
            UpdateWriterViewModel model = new UpdateWriterViewModel();
            model.About = values.About;
            model.FullName = values.FullName;
            model.Email = values.Email;
            model.Password = values.Password;
            model.Id = values.Id;
            model.WriterImage = values.WriterImage;
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(UpdateWriterViewModel writerViewModel)
        {
            //Validation for ConfirmPassword
            if (!ModelState.IsValid)
            {
                return View();
            }

            Writer writer = new Writer
            {
                Id = writerViewModel.Id,
                FullName = writerViewModel.FullName,
                Email = writerViewModel.Email,
                WriterImage = writerViewModel.WriterImage,
                About = writerViewModel.About,
                Password = writerViewModel.Password
            };

            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                //Statusu basta false yapip admin tarafinda onaylatabiliriz
                writer.Status = true;
                writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    //Viewin Modeline validation errorları ekle
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //viewi dondur, dondurdugu zaman validation errorlari da eklenmis bir sekilde dondurecek, bu  validation errorlari viewda goruntuleyebiliriz
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]    
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage model)
        {
            Writer writer = new Writer();
            if(model.WriterImage != null)
            {
                var newImageName = FileHelper.Add(model.WriterImage);
                writer.WriterImage = newImageName;
            }
            writer.Email = model.Email;
            writer.FullName = model.FullName;
            writer.Password = model.Password;
            writer.About = model.About;
            writer.Status = true;
            writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
