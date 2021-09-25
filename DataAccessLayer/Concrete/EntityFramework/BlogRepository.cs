using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class BlogRepository : IBlogDal
    {
        public void Add(Blog blog)
        {
            //Disposable pattern - context bu method için oluşturulur
            //Kullanılır ve silinir
            using(var c = new Context())
            {
                c.Add(blog);
                c.SaveChanges();
            }
        }

        public void Delete(Blog blog)
        {
            using(var c = new Context())
            {
                c.Remove(blog);
                c.SaveChanges();
            }
        }

        public List<Blog> GetAll()
        {
            using(var c = new Context())
            {
                return c.Blogs.ToList();
            }
        }

        public Blog GetById(int id)
        {
            using(var c = new Context())
            {
                return c.Blogs.Find(id);
            }
        }

        public void Insert(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog blog)
        {
            using(var c = new Context())
            {
                c.Update(blog);
                c.SaveChanges();
            }
        }
    }
}
