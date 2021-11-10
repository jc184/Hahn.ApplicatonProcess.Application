using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Domain.Assets;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Users;
using Hahn.ApplicatonProcess.July2021.Web.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.July2021.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAssetRepository, AssetRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFDBContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DDDConnectionString")));
        }

        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFDBContext>(options =>
                     options.UseInMemoryDatabase("DDDHahn"));

        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services
                .AddScoped<UserService>();
        }

        //private static void AddTestData(EFDBContext context)
        //{
        //    var testUser1 = new User(string firstName, )
        //    {
        //        Id = "abc123",
        //        FirstName = "Luke",
        //        LastName = "Skywalker"
        //    };

        //    context.Users.Add(testUser1);

        //    var testPost1 = new DbModels.Post
        //    {
        //        Id = "def234",
        //        UserId = testUser1.Id,
        //        Content = "What a piece of junk!"
        //    };

        //    context.Posts.Add(testPost1);

        //    context.SaveChanges();
        //}
    }
}
