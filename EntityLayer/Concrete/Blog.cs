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
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; } //kucuk resim(profil resmi gibi)
        public string BlogImage { get; set; } //buyuk resim
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        //Category nesnesindeki id propertysinin ismiyle aynı olmalı
        public int CategoryID { get; set; }

        //ilişkisi alınacak entity türünde
        public Category Category { get; set; }

        //İliskili oldugu Writerin id'si
        public int WriterId { get; set; }

        //İliskili oldugu writer
        public Writer writer { get; set; }


        //Bir blogun birden fazla yorumu olabilir
        public List<Comment> Comments { get; set; }
    }
}
