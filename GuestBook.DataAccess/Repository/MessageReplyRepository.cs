using Dapper;
using GuestBook.Configuration;
using GuestBook.DataAccess.Repository.IRepository;
using GuestBook.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.DataAccess.Repository
{
    public class MessageReplyRepository : IRepository<MessageReply>
    {
        private readonly IDbConnection _db;
        public MessageReplyRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public void Add(MessageReply entity)
        {
            _db.Execute(SQLCommands.MessageReply.Add, entity);
        }

        public IEnumerable<MessageReply> GetAll()
        {
            IEnumerable<MessageReply> entities = _db.Query<MessageReply>(SQLCommands.MessageReply.GetAll).ToList();
            return entities;
        }

        public IEnumerable<MessageReply> GetAllById(int id)
        {
            IEnumerable<MessageReply> entities = _db.Query<MessageReply>(SQLCommands.MessageReply.GetAllById, new { @messageId = id }).ToList();
            return entities;
        }

        public void Delete(int id)
        {
            _db.Execute(SQLCommands.MessageReply.Delete, new { @messageReplyId = id });
        }

        public MessageReply Find(int id)
        {
            throw new NotImplementedException();
        }        

        public void Update(MessageReply entity)
        {
            throw new NotImplementedException();
        }
    }
}
