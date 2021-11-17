using Hahn.ApplicatonProcess.July2021.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
