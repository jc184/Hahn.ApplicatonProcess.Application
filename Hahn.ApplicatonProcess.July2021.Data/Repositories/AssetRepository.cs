using Hahn.ApplicatonProcess.July2021.Domain.Assets;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repositories
{
    public class AssetRepository : RepositoryBase<Asset>, IAssetRepository
    {
        public AssetRepository(EFDBContext dbContext) : base(dbContext)
        {
        }
    }
}
