using BetMachine.Domain.Interfaces;

namespace BetMachine.Service.Services
{
    /// <summary>
    /// Unit of work implementation
    /// </summary>
    /// <param name="context"></param>
    /// <param name="match"></param>
    /// <param name="matchOdd"></param>
    public class UnitOfWork(DataContext context, IMatchRepository match, IMatchOddRepository matchOdd)
        : IUnitOfWork
    {
        public IMatchRepository Matches { get; } = match;
        public IMatchOddRepository MatchOdds { get; } = matchOdd;

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}