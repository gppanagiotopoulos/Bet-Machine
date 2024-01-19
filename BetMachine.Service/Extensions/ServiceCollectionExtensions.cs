using BetMachine.Domain.Interfaces;
using BetMachine.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BetMachine.Service.Extensions
{
    /// <summary>
    /// Extension Methods for Application Services
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register Repository Services and DataContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <exception cref="Exception"></exception>
        public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            if (connectionString is null) throw new Exception($"Unknown ConnectionString");
            //Register DataContext
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString,
                optionsBuilder => optionsBuilder.MigrationsAssembly("BetMachine")));
            //Register repositories
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IMatchOddRepository, MatchOddRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}