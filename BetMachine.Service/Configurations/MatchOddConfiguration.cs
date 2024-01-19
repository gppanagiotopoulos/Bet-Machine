using BetMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetMachine.Service.Configurations
{
    /// <summary>
    /// Configuration for entity MatchOdd in fluent api
    /// </summary>
    public class MatchOddConfiguration : IEntityTypeConfiguration<MatchOdd>
    {
        public void Configure(EntityTypeBuilder<MatchOdd> builder)
        {
            // Set table Name
            builder.ToTable("MatchOdds");
            // Assign Primary Key
            builder.HasKey(k => k.Id);
            //Fields configuration
            builder.Property(p => p.Specifier).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Odd).IsRequired();


            builder
                .HasOne(m => m.Match)
                .WithMany(o => o.MatchOdds)
                .HasForeignKey(b =>
                    b.MatchId) // MatchId is the Foreign key in MatchOdds table, specifies which property is the foreign key
                .OnDelete(DeleteBehavior.Cascade); //Delete behaviour
        }
    }
}