using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAllByWriter(int id)
        {
            return _blogDal.GetAll(b => b.WriterId == id);
        }

        public List<Blog> GetAllWithCategory()
        {
            return _blogDal.GetAllWithCategory();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(b => b.BlogId == id);
        }

        public List<Blog> GetLastBlogsWithCount(int count)
        {
            return _blogDal.GetAll().Take(count).ToList();
        }

        public List<Blog> GetLastBlogsWithCategoryByCount(int count)
        {
            return _blogDal.GetAllWithCategory().Take(count).ToList();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetAllWithCategoryByWriterId(int id)
        {
            return _blogDal.GetAllWithCategory(b => b.WriterId == id);
        }
    }
}
