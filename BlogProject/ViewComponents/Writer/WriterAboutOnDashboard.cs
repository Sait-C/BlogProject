using BusinessLayer.Concrete;
using CoreLayer.Extensions;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(
            new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            /*
             * null-coalescing operator ??
             * -> User.GetId() == null ? default(int) : User.GetId().Value;
             * */
            int loggedUserId = User.GetId() ?? default(int);
            var values = writerManager.GetWriterById(loggedUserId);
            return View(values);
        }
    }
}
