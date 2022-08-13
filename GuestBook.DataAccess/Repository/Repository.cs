using Dapper;
using GuestBook.Configuration;
using GuestBook.DataAccess.Repository.IRepository;
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
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbConnection _db;
        public Repository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public void Add(T entity)
        {
            _db.Execute(SQLCommands.Add, entity);
        }

        public void Delete(int id)
        {
            _db.Execute(SQLCommands.Delete, new { id });
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> entities = _db.Query<T>(SQLCommands.GetAll).ToList();
            return entities;
        }

        public T Find(int id)
        {
            T entity = _db.QuerySingleOrDefault<T>(SQLCommands.Find, new { id });
            return entity;
        }

        public void Update(T entity)
        {
            _db.Execute(SQLCommands.Update, entity);
        }
    }
}
