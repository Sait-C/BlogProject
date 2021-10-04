using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key] //Hangi sütunun birincil anahtar olarak tanimlandigini belirtmemizi saglar
        public int Id { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }
        public string WriterImage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
