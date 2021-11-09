using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Users
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
