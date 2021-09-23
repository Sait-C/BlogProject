using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //Erisim Belirleyici Turu - Degisken Turu - Isim - { get; set; }

        [Key] //Hangi sütunun birincil anahtar olarak tanimlandigini belirtmemizi saglar
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        //İliskili tablolarda silme islemi problem olusturdugundan dolayi
        //biz bu categoryi silmek yerine onun durumunu aktif veya pasif yapacagiz
        //o yuzden bu Status bool degiskenini kullanacagiz
        public bool CategoryStatus { get; set; }
        public List<Blog> Blogs { get; set; } //ilişki için
    }
}
