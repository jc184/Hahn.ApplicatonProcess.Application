using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
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

                        var user4 = new User()
                        {
                            Id = 4,
                            FirstName = "michel",
                            LastName = "dupont",
                            Age = 32,
                            Address = "21 Rue Napoleon, Paris, P23 6TF",
                            Email = "michel.dupont123@wanadoo.com"
                        };
                        context.Users.Add(user4);

                        var user5 = new User()
                        {
                            Id = 5,
                            FirstName = "angela",
                            LastName = "smith",
                            Age = 36,
                            Address = "45 Dumbarton Road, Glasgow, G3 5TY",
                            Email = "angela.smith@yahoo.com"
                        };
                        context.Users.Add(user5);
                    }

                    // Add sample assets
                    if (!context.Assets.Any())
                    {
                        var asset1 = new Asset()
                        {
                            Id = 1,
                            Asset_Id = "bitcoin",
                            Name = "BitCoin",
                            Symbol = "BTC",
                            UserId = 1
                        };
                        context.Assets.Add(asset1);

                        var asset2 = new Asset()
                        {
                            Id = 2,
                            Asset_Id = "ethereum",
                            Name = "Ethereum",
                            Symbol = "ETH",
                            UserId = 1
                        };
                        context.Assets.Add(asset2);

                        var asset3 = new Asset()
                        {
                            Id = 3,
                            Asset_Id = "binance",
                            Name = "Binance Coin",
                            Symbol = "BNB",
                            UserId = 2
                        };
                        context.Assets.Add(asset3);

                        var asset4 = new Asset()
                        {
                            Id = 4,
                            Asset_Id = "solana",
                            Name = "Solana",
                            Symbol = "SOL",
                            UserId = 3
                        };
                        context.Assets.Add(asset4);

                        var asset5 = new Asset()
                        {
                            Id = 5,
                            Asset_Id = "cardano",
                            Name = "Cardano",
                            Symbol = "ADA",
                            UserId = 4
                        };
                        context.Assets.Add(asset5);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
