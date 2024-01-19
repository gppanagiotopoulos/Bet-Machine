using BetMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BetMachine.Service.Services
{
    /// <summary>
    /// Represents entity for the configuring DB context
    /// </summary>  
    public class DataContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DataContext()
        {
        }

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet for table Matches
        /// </summary>
        public DbSet<Match> Matches { get; set; }

        /// <summary>
        /// DbSet for table MatchOdds
        /// </summary>
        public DbSet<MatchOdd> MatchOdds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Loading all configurations type IEntityTypeConfiguration {ModelsConfiguration} 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}