using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<Message> Message { get; }
        IRepository<MessageReply> MessageReply { get; }
    }
}
