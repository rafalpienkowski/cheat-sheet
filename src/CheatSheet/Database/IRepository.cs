using System;
using System.Linq;
using System.Linq.Expressions;

namespace CheatSheet.Database
{
    public interface IRepository
    {
         IQueryable<T> All<T>() where T : class;
         void Create<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
         void Update<T>(T entity) where T : class;
         void ExecuteProcedure(string procedureCommand);
         IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;
         T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
         bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}