using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Domain.Base;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDBContext _dbContext;

        public UnitOfWork(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
