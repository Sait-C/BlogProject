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
        MessageManager messageManager = new MessageManager(new
            EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            //p degeri sessiondan gelen deger olacak simdilik manuel yazalim
            string p = "coktasmuharrem@gmail.com";
            var values = messageManager.GetAllByReceiver(p);
            return View(values);
        }
    }
}
