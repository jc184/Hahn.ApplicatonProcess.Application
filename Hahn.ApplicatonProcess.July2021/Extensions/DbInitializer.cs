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

                    //add sample users
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

                        var user3 = new User()
                        {
                            Id = 3,
                            FirstName = "joe",
                            LastName = "bloggs",
                            Age = 23,
                            Address = "24 Old Street, Anytown, AT12 4EF",
                            Email = "john.bloggs321@gmail.com"
                        };
                        context.Users.Add(user3);
                    }

                    // Add sample assets
                    if (!context.Assets.Any())
                    {
                        var asset1 = new Asset()
                        {
                            Id = "bitcoin",
                            Name = "bitcoin",
                            Symbol = "BTC",
                            UserId = 1
                        };
                        context.Assets.Add(asset1);

                        var asset2 = new Asset()
                        {
                            Id = "ethereum",
                            Name = "Ethereum",
                            Symbol = "ETH",
                            UserId = 1
                        };
                        context.Assets.Add(asset2);

                        var asset3 = new Asset()
                        {
                            Id = "binance",
                            Name = "Binance Coin",
                            Symbol = "BNB",
                            UserId = 2
                        };
                        context.Assets.Add(asset3);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
