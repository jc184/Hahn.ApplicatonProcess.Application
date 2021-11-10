using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Hahn.ApplicatonProcess.July2021.Web.Extensions
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<EFDBContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<EFDBContext>())
                {

                    //add admin user
                    if (!context.Users.Any())
                    {
                        var user1 = new User()
                        {
                            Id = 1,
                            FirstName = "james",
                            LastName = "chalmers",
                            Age = 55,
                            Address = "37 Forteath Avenue, Elgin, IV30 1TF",
                            Email = "james.chalmers184@gmail.com"
                        };
                        context.Users.Add(user1);

                        var user2 = new User()
                        {
                            Id = 2,
                            FirstName = "john",
                            LastName = "smith",
                            Age = 55,
                            Address = "24 New Street, Sometown, ST23 6TY",
                            Email = "john.smith123@gmail.com"
                        };
                        context.Users.Add(user2);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
