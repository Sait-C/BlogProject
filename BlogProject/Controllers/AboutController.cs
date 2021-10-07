using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());

        public IActionResult Index()
        {
            var values = aboutManager.GetAll();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
            //View yüklenirken çalışır.(Sosyal medya hesaplarımızın takipçi sayısını çekip
            //bu viewda göstereceğiz)
            return PartialView(); //This is our response
        }
    }
}
