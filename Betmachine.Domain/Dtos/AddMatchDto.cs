using BetMachine.Domain.Types;

namespace BetMachine.Domain.Dtos
{
    /// <summary>
    /// Data transfer object for adding a match 
    /// </summary>
    public class AddMatchDto
    {
        #region Columns

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
    }
}