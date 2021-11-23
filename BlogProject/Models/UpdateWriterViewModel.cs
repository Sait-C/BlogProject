using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class UpdateWriterViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }
        public string WriterImage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}
