using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key] //Hangi sütunun birincil anahtar olarak tanimlandigini belirtmemizi saglar
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; } //kucuk resim(profil resmi gibi)
        public string BlogImage { get; set; } //buyuk resim
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
