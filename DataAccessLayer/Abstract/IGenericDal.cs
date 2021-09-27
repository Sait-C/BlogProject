using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //where ile disaridan alacagimiz entity-veya herhangi bir tip- icin kosul yaziyoruz.
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);

        //Şartlı listeleme yapmak istersek, filter parametresi ekleriz
        //Şartlı listeleme yapmak istemeyip tum veriyi getirmek istersek
        //Filter parametresi gondermeyiz ve default olarak null olur
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T GetById(int id);
    }
}
