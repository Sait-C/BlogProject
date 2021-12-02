using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetAllWithSenderByReceiverId(int id)
        {
            using(Context c = new Context())
            {
                return c.Message2s.Include(x => x.Sender)
                    .Where(x => x.ReceiverId == id).ToList();
            }
        }
    }
}
