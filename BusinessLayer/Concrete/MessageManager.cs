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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message t)
        {
            _messageDal.Insert(t);
        }

        public void Delete(Message t)
        {
            _messageDal.Delete(t);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAllByReceiver(string mail)
        {
            //alıcısı biz oldugumuz mesajlar
            return _messageDal.GetAll(x => x.Receiver == mail);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void Update(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
