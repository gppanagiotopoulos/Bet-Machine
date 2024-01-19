using BetMachine.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace BetMachine.Extensions
{
    /// <summary>
    /// Extension Methods for Migration
    /// </summary>
    public static class MigrationExtensions
    {
        /// <summary>
        ///  Asynchronously applies any pending migrations for the context to the database.
        ///  Will create the database if it does not already exist.
        /// </summary>
        /// <param name="app">WebApplication</param>
        /// <returns>The app</returns>
        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {
            using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope is not null)
            {
                await using var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Migration Error", ex);
                }
            }
        }
    }
}