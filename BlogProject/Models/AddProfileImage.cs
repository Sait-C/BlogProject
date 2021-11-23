using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class AddProfileImage
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }
        public IFormFile WriterImage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
