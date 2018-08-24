using System.Collections.Generic;
using CheatSheet.Database;

namespace CheatSheet.Services
{
    public interface IActionManager
    {
         void Create(BaseEntity entity);
         void Update(BaseEntity entity);
         void Delete(BaseEntity entity);
         IEnumerable<BaseEntity> GetAll();
         IUnitOfWork UnitOfWork { get; }
         void SaveChanges();
    }
}