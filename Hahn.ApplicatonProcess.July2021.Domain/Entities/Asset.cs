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
    public class Asset : BaseEntity<string>
    {
        public Asset()
        {
        }

        public Asset(string id, string name, string symbol, int userId)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            UserId = userId;
        }

        public string Name { get; set; }

        public string Symbol { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public static implicit operator DbSet<object>(Asset v)
        {
            throw new NotImplementedException();
        }
    }
}
