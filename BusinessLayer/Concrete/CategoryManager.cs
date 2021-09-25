using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //Oyle bir sey yapmaliyim ki, butun generic repositoryi cagirmak yerine
        //Sadece ilgili uzerinde calisacagim entitye ait repositoryi degerini
        //cagirayim ve onunla islem yapayim


        //EfCategoryRepository efCategoryRepository = new EfCategoryRepository();
        //Boylece EntityFrameworke olan bağımlılığımızdan kurtulduk.
        //Dependency Injectiona daha uygun oldu.
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
