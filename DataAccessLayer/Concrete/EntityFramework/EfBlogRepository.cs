using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAllWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
            using(var c = new Context())
            {
                //Yaptigimiz sey, contexten Blogs verilerini al, ama
                //Include methodu ile de Categoryi include et.

                //Include islemi uygulanirken hangi entity include edilecek.
                //Yani hangi entity bunun icerisine dahil edilecek
                /*return c.Blogs.Include(x => x.Category).ToList();*/
                //Her bir blogun kategorisinin bilgilerine de erismek icin
                //Include ediyoruz

                return filter == null ? c.Blogs.Include(x => x.Category).ToList()
                       : c.Blogs.Include(x => x.Category).Where(filter).ToList();
            } 
        }
    }
}
