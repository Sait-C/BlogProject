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
    public class NewsLettersController : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(
            new EfNewsLetterRepository());

        /*Bu şekilde yaptığımızda form tagına action attributesi eklemek zorunda kalıyoruz
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            newsLetterManager.AddNewsLetter(p);
            return PartialView();
        }
        */

        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            newsLetterManager.AddNewsLetter(p);
            return RedirectToAction("Index", "Blogs");
        }
    }
}
