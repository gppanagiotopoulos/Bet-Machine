namespace BetMachine.Domain.Dtos
{
    public class AddMatchOddDto
    {
        #region Columns

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
    }
}