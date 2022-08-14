using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        T Find(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
