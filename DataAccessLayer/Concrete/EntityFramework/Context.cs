using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    //Context classı, biz burda baglantı adresimizi
    //yani connection stringimizi tanimliycaz
    //Bir web config dosyası yok baglantı adresi farkli sekilde tanimlaniyor
    //Connection stringini bir Context classi ile tanimliyor olacagiz
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //baglanti stringimizi tanimlayacagiz
            //optionsBuilder : DbContext options olusturucusu

            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=CoreBlogDb;integrated security=true;");
        }
    }
}
