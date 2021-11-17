using Hahn.ApplicatonProcess.July2021.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class Asset : BaseEntity<int>
    {
        public Asset()
        {
        }

        public Asset(string assetId, string name, string symbol, int userId)
        {
            Asset_Id = assetId;
            Name = name;
            Symbol = symbol;
            UserId = userId;
        }

        public string Asset_Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

    }
}
