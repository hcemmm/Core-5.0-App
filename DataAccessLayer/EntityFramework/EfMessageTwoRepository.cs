﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageTwoRepository : GenericRepository<MessageTwo>, IMessageTwoDal
    {
        public List<MessageTwo> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.MessageTwos.Include(b => b.SenderUser).Where(x => x.MessageReceiverID == id).ToList();
            }
        }
    }
}
