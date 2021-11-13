using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        //void Add(Blog blog);
        //void Delete(Blog blog);
        //void Update(Blog blog);
        //List<Blog> GetAll();
        //Blog GetById(int id);
        List<Blog> GetAllWithCategory();
        List<Blog> GetAllByWriter(int id);
        List<Blog> GetBlogById(int id);
        List<Blog> GetLastBlogsWithCount(int count);

        List<Blog> GetAllWithCategoryByWriterId(int id);
    }
}