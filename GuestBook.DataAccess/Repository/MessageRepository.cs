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
    public class MessageRepository : IRepository<Message>
    {
        private readonly IDbConnection _db;
        public MessageRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public void Add(Message entity)
        {
            _db.Execute(SQLCommands.Message.Add, entity);
        }

        public void Delete(int id)
        {
            _db.Execute(SQLCommands.Message.Delete, new { @messageId = id });
        }

        public IEnumerable<Message> GetAll()
        {
            IEnumerable<Message> entities = _db.Query<Message>(SQLCommands.Message.GetAll).ToList();
            return entities;
        }

        public Message Find(int id)
        {
            Message entity = _db.QuerySingleOrDefault<Message>(SQLCommands.Message.Find, new { @messageId = id });
            return entity;
        }

        public void Update(Message entity)
        {
            _db.Execute(SQLCommands.Message.Update, entity);
        }

        public IEnumerable<Message> GetAllById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
