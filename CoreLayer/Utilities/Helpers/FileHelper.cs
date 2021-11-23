using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            /*
            var newImageName = Guid.NewGuid().ToString() + "_" + 
                DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + 
                DateTime.Now.Year + extension;
            */
            var newImageName = $"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/WriterImages/", newImageName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            return newImageName;
        }
    }
}
