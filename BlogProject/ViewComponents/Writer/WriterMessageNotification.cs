using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new
            EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            //p degeri sessiondan gelen deger olacak simdilik manuel yazalim
            int p = 1;
            var values = messageManager.GetAllWithSenderByReceiverId(p);
            return View(values);
        }
    }
}
