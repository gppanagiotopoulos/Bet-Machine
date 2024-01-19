using BetMachine.Domain.Models;

namespace BetMachine.Domain.Interfaces
{
    /// <summary>
    /// Repository that contains all CRUD for Match entity
    /// </summary>
    public interface IMatchRepository : IRepository<Match>
    {
    }
}