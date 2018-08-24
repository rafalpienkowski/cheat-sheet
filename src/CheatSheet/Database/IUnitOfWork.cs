namespace CheatSheet.Database
{
    public interface IUnitOfWork
    {
         void BeginTransaction();
         void RollbackTransaction();
         void CommitTransaction();
         void SaveChanges();
    }
}