using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key] //Hangi sütunun birincil anahtar olarak tanimlandigini belirtmemizi saglar
        public int Id { get; set; }
        public string ContactUserName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ContactDate { get; set; }
        public bool Status { get; set; }
    }
}
