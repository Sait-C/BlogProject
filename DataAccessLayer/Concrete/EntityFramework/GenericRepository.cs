using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using (var c = new Context())
            {
                c.Remove(t);
                c.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var c = new Context())
            {
                //c.Set<T>() -> c.Blogs gibi
                //Eger T Blog ise c.Set<T>() = c.Blogs
                //Eger T Category ise c.Set<T>() = c.Categories
                //return c.Set<T>().ToList();

                return filter == null
                    ? c.Set<T>().ToList()
                    : c.Set<T>().Where(filter).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Find(id);
            }
        }

        public void Insert(T t)
        {
            using (var c = new Context())
            {
                c.Add(t);
                c.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (var c = new Context())
            {
                c.Update(t);
                c.SaveChanges();
            }
        }
    }
}
