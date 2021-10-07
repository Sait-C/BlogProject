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
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(
            new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /*
         HttpPost istegi atildiginda onu burada yakalayıp bir response donmemiz gerekiyor.
         Bu noktada formdaki bilgileri alıp parametre olan Contact entitysine map edip veri tabanına eklememiz gerekiyor.
        */
        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            contactManager.ContactAdd(p);
            //Response olarak ekleme işlemlerini gerçekleştirecek ve Blogs/Index.cshtml sayfasına yönlendirecek.
            return RedirectToAction("Index", "Blogs");
        }
    }
}
