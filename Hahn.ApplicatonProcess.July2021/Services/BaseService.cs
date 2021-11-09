using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.July2021.Web.Services
{
    public class BaseService
    {
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected internal IUnitOfWork UnitOfWork { get; set; }
    }
}
