using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
    }
}

//Burda tanimlamis oldugum butun entityler icin abstract klasoru icerisinde
//birer tane DataAccessLayer interfacesi tanimlayacagim.Boylece hicbir entityim
//ciplak kalmayacak
