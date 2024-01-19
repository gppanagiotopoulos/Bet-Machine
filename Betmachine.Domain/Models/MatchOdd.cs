namespace BetMachine.Domain.Models
{
    /// <summary>
    /// Odds of match
    /// </summary>
    public class MatchOdd
    {
        #region Columns

        /// <summary>
        /// Unique identifier of the odd.  
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The match id
        /// </summary>
        public int MatchId { get; set; }

        /// <summary>
        /// Specifier of the match
        /// </summary>
        public string Specifier { get; set; } = string.Empty;

        /// <summary>
        /// Odd of the match
        /// </summary>
        public double Odd { get; set; }

        #endregion

        #region Relations

        /// <summary>
        /// Relation to MatchOdd
        /// </summary>
        public virtual required Match Match { get; set; }

        #endregion
    }
}