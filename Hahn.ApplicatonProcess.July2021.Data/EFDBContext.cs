using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public class EFDBContext : DbContext
    {

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {

//            using (var context = new EFDBContext(options =>
//                     options.UseInMemoryDatabase("DDDHahn")))
//            {
//                context.Database.EnsureCreated();
                
//}
//            modelBuilder.Entity<User>().HasData(new User("james", "chalmers", "37 Forteath Avenue, Elgin", 55, "james.chalmers184@gmail.com"));

//            modelBuilder.Entity<User>().HasData(new User("john", "smith", "1 New Street, Sometown", 34, "john.smith123@gmail.com"));

//            //modelBuilder.Entity<Asset>().HasData(new Asset(1, "Title1", "Content1") { Id = 1 });
//            //modelBuilder.Entity<Asset>().HasData(new Asset(2, "Title2", "Content2") { Id = 1 });
//            //modelBuilder.Entity<Asset>().HasData(new Asset(3, "Title3", "Content3") { Id = 2 });

//        }
    }
}
