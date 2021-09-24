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


        EfCategoryRepository efCategoryRepository;
        public CategoryManager()
        {
            efCategoryRepository = new EfCategoryRepository();
        }

        public void Add(Category category)
        {
            efCategoryRepository.Insert(category);
        }

        public void Delete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return efCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }

        public void Update(Category category)
        {
            efCategoryRepository.Update(category);
        }
    }
}
