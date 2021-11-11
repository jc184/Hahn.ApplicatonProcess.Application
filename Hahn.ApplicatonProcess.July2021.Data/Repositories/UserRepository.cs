using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Users;


namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(EFDBContext dbContext) : base(dbContext)
        {
        }

    }
}
