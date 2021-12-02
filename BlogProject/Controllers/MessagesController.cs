using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class MessagesController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(
            new EfMessage2Repository());

        public IActionResult InBox()
        {
            int id = 1;
            var values = message2Manager.GetAllWithSenderByReceiverId(id);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.GetById(id);
            return View(value);
        }
    }
}
