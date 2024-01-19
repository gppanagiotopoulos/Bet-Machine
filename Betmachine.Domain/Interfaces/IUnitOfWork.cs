namespace BetMachine.Domain.Interfaces
{
    /// <summary>
    /// Unit of work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repository for Match
        /// </summary>
        IMatchRepository Matches { get; }

        /// <summary>
        /// Repository for MatchOdd
        /// </summary>
        IMatchOddRepository MatchOdds { get; }

        /// <summary>
        /// Complete persistent save changes to database
        /// </summary>
        /// <returns></returns>
        public Task<int> CompleteAsync();
    }
}