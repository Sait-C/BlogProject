using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        //yani benim proje seviyesinde tanimladigim tum kurallardan muaf ol
        [AllowAnonymous] //zaten bu bir kac tane action icin veya controller icin yazilir 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer p)
        {
            using(Context context = new Context())
            {
                var dataValue = context.Writers.FirstOrDefault(
                    x => x.Email == p.Email && x.Password == p.Password);
                if(dataValue != null)
                {
                    HttpContext.Session.SetString("username", p.Email);
                    return RedirectToAction("Index", "Writer");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
