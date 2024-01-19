using BetMachine.Domain.Types;

namespace BetMachine.Domain.Models
{
    /// <summary>
    /// The match class  
    /// </summary>
    public class Match
    {
        #region Columns

        /// <summary>
        /// Unique identifier of the match.  
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Match description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Date of the match
        /// </summary>
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// Time of the match
        /// </summary>
        public TimeSpan MatchTime { get; set; } = default;

        /// <summary>
        /// First team 
        /// </summary>
        public string TeamA { get; set; } = string.Empty;

        /// <summary>
        /// Second team
        /// </summary>
        public string TeamB { get; set; } = string.Empty;

        /// <summary>
        /// Sport Type
        /// </summary>
        public Sports Sport { get; set; } = Sports.None;

        #endregion


        #region Relations

        /// <summary>
        /// Relation collection of MatchOdds
        /// </summary>
        public virtual ICollection<MatchOdd>? MatchOdds { get; set; }

        #endregion
    }
}