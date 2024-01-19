using Microsoft.EntityFrameworkCore;
using BetMachine.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BetMachine.Service.Configurations
{
    /// <summary>
    /// Configuration for entity Match in fluent api
    /// </summary>
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            // Set table Name
            builder.ToTable("Matches");
            // Assign Primary Key
            builder.HasKey(k => k.Id);
            //Fields configuration
            builder.Property(p => p.Description).HasMaxLength(150).IsRequired();
            builder.Property(p => p.MatchDate).HasColumnType("Date").HasDefaultValue(DateTime.MinValue).IsRequired();
            builder.Property(p => p.MatchTime).HasColumnType("Time").IsRequired();
            builder.Property(p => p.TeamA).HasMaxLength(100).IsRequired();
            builder.Property(p => p.TeamB).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sport).IsRequired();

            //Configure relations
/*
            builder
                .HasMany(a => a.MatchOdds) // Match has many MatchOdds, specifies the 'many' side of the relationship
                .WithOne(b =>
                    b.Match) // MatchOdd is associated with one Match, specifies the 'one' side of the relationship
                .HasForeignKey(b =>
                    b.MatchId) // MatchId is the Foreign key in MatchOdds table, specifies which property is the foreign key
                .OnDelete(DeleteBehavior.Cascade); //Delete behaviour
*/
        }
    }
}