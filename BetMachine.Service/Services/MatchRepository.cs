using BetMachine.Domain.Interfaces;
using BetMachine.Domain.Models;

namespace BetMachine.Service.Services
{
    public class MatchRepository(DataContext context) : Repository<Match>(context), IMatchRepository
    {
        //Implement methods here inherit from interface IMatchRepository
    }
}