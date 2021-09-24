using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    //Imzalari tekrar tekrar yazmamak icin IGenericDali olusturduk.
    //Implementasyonlari da tekrar tekrar yazmak istemeyiz.
    //Bu yuzden GenericRepositoryi olusturduk.
    //EfCategoryRepository, GenericRepository den miras aliyor,
    //Category tipini kullaniyor.Yani aslinda GenericRepositorydeki
    //Operasyonlar(CRUD)i aliyor operasyonlara da Category tipini veriyor.
    //ICategoryDal'dan da miras aliyor.Bu bize hem business tarafinda avantaj
    //saglayacak, cunku ConstructorMethodda biz ICategoryDal alacagiz.
    //Boylece hem bagimlilik ortadan kalkacak hem de newlememis olacagiz.
    //Hem de eger Categorye ozel bir veri tabani operasyonu varsa
    //Onu da implemente etmis olacagiz.
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
    }
}
