using GuestBook.DataAccess.Repository.IRepository;
using GuestBook.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConfiguration configuration)
        {
            Message = new MessageRepository(configuration);
            MessageReply = new MessageReplyRepository(configuration);
        }

        public IRepository<Message> Message { get; private set; }
        public IRepository<MessageReply> MessageReply { get; private set; }
    }
}
