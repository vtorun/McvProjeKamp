using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetListByHeadingId(int id);
        void MessageAdd(Message message);
        Category GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
