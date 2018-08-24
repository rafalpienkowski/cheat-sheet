using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheatSheet.Database
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Any<T>(predicate);
        }

        public void Create<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            foreach(var obj in objects)
            {
                _context.Set<T>().Remove(obj);
            }
        }

        public void ExecuteProcedure(string procedureCommand)
        {
            _context.Database.ExecuteSqlCommand(procedureCommand);
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().AsQueryable().Where<T>(predicate).AsQueryable();
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().AsQueryable().FirstOrDefault<T>(predicate);
        }

        public void Update<T>(T entity) where T : class
        {
            try
            {
                var entry = _context.Entry(entity);
                _context.Set<T>().Attach(entity);
                entry.State = EntityState.Modified;
            }
            catch(Exception ex)
            {
                throw new Exception("Update entity exception", ex);
            }
        }
    }
}