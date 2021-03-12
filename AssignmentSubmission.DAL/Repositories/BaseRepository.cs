using AssignmentSubmission.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSubmission.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public AssgnmentDBContext _dbContext;
        public DbSet<T> Dbset;
        public BaseRepository(AssgnmentDBContext context)
        {
            _dbContext = context;
            Dbset = context.Set<T>();
        }
        public T GetById(int id)
        {
            //var i= (from a in Dbset where  a.ID == id select a)
            return Dbset.Find(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(Dbset);
        }
        public IQueryable<T> GetAll()
        {
            return Dbset;
        }

        public void Insert(T entity)
        {
            Dbset.Add(entity);
        }
        public object Add(T entity)
        {
            var res = Dbset.Add(entity);
            return res;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void InsertRange(List<T> entityList)
        {
            Dbset.AddRange(entityList);
        }

        public void RemoveRange(List<T> entityList)
        {
            Dbset.RemoveRange(entityList);
        }

        public void Attach(T entity)
        {
            Dbset.Attach(entity);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
