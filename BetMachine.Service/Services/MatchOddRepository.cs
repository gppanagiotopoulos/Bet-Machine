using BetMachine.Domain.Interfaces;
using BetMachine.Domain.Models;

namespace BetMachine.Service.Services
{
    public class MatchOddRepository(DataContext context) : Repository<MatchOdd>(context), IMatchOddRepository
    {
        //Implement methods here inherit from interface IMatchOddRepository
    }
}