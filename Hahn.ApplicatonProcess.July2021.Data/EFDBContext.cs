using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class EFDBContext : DbContext
    {

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(s => s.Assets);
            modelBuilder.Entity<Asset>().HasKey(a => a.Id );
        }


    }
}
