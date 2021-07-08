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

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }
        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListByMessageId(int id)
        {
            throw new NotImplementedException();
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Add(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }


    }
}
