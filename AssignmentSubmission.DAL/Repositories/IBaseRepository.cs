using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSubmission.DAL.Repositories
{
    public interface IBaseRepository<T> : IDisposable
    {
        Task<IQueryable<T>> GetAllAsync();
        IQueryable<T> GetAll();

        T GetById(int id);

        void Update(T entity);

        void Insert(T entity);
        object Add(T entity);

        void Delete(T entity);

        void InsertRange(List<T> entityList);

        void RemoveRange(List<T> entityList);

        void Attach(T entity);

        void SaveChanges();

    }
}
