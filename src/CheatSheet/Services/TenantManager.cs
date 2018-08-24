using System;
using System.Collections.Generic;
using System.Linq;
using CheatSheet.Database;

namespace CheatSheet.Services
{
    public class TenantManager : ITenantManager
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TenantManager(IRepository repository, IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public void Create(BaseEntity entity)
        {
            var tenant = (Tenant)entity;
            _repository.Create<Tenant>(tenant);
        }

        public void Delete(BaseEntity entity)
        {
            var tenant = (Tenant)entity;
            _repository.Delete<Tenant>(tenant);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Tenant>().ToList<Tenant>();
        }

        public Tenant GetTenant(Guid id)
        {
            return _repository.All<Tenant>().FirstOrDefault(t => t.Id.Equals(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            var tenant = (Tenant)entity;
            _repository.Update<Tenant>(tenant);
        }
    }
}