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
    public class MessageTwoManager : IMessageTwoService
    {
        IMessageTwoDal _messageTwoDal;

        public MessageTwoManager(IMessageTwoDal messageTwoDal)
        {
            _messageTwoDal = messageTwoDal;
        }

        public List<MessageTwo> GetList()
        {
            return _messageTwoDal.GetListAll();
        }

        public List<MessageTwo> GetInboxListWithByWriter(int m)
        {
            return _messageTwoDal.GetListWithMessageByWriter(m);
        }      

        public void TAdd(MessageTwo t)
        {
            _messageTwoDal.Insert(t);
        }

        public void TDelete(MessageTwo t)
        {
            _messageTwoDal.Delete(t);
        }

        public MessageTwo TGetByID(int id)
        {
            return _messageTwoDal.GetByID(id);
        }

        public void TUpdate(MessageTwo t)
        {
             _messageTwoDal.Update(t);
        }
    }
}
