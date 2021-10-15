using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Index(Writer p)
        {
            //Login Process Code
            using(Context context = new Context())
            {
                var dataValue = context.Writers.FirstOrDefault(
                        x => x.Email == p.Email && x.Password == p.Password);
                if(dataValue != null)
                {
                    //Talepler, Yetkiler
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, p.Email)
                    };
                    //ikinci parametreye herhangi string deger gondermen gerekiyor
                    var userIdentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
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
/*
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
*/