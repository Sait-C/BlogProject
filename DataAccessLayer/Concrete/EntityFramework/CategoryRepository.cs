using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void Add(Category category)
        {
            c.Add(category);
            c.SaveChanges(); //değişiklikleri kaydeder
            //Ado net de SaveChanges'in karşılığı: ExecuteNonQuery
        }

        public void Delete(Category category)
        {
            c.Remove(category); //contextimizdeki categories tablosundan siliyoruz
            c.SaveChanges(); //veri tabanına yansıması için değişiklikleri kaydet diyoruz
        }

        public List<Category> GetAll()
        {
            return c.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public void Insert(Category t)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            c.Update(category);
            c.SaveChanges(); //entity frameworkde sadece bu yazılıyordu, ama Entity Framework Core ile gelen bir Update methodu var
        }
    }
}
