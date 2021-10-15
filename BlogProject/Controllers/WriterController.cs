using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //[Authorize] sadece bu sayfa icin gecerli olur
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
    }
}
