using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.July2021.Domain.Users
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
