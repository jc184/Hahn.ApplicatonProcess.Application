using Hahn.ApplicatonProcess.July2021.Domain.Assets;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
    public class AssetRepository : RepositoryBase<Asset>, IAssetRepository
    {
        public AssetRepository(EFDBContext dbContext) : base(dbContext)
        {
        }
    }
}
