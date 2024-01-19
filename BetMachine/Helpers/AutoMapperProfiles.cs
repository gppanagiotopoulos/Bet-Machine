using AutoMapper;
using BetMachine.Domain.Dtos;
using BetMachine.Domain.Models;

namespace BetMachine.Helpers
{
    /// <summary>
    /// Object-object mapping by transforming an input object of one type into an output object of a different type. 
    /// Provides interesting conventions to take the dirty work out of figuring out how to map type A to type B
    /// </summary>  
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region Match Maps

            CreateMap<AddMatchDto, Match>().ReverseMap();
            CreateMap<MatchDto, Match>().ReverseMap();

            #endregion

            #region Match Odd Maps

            CreateMap<AddMatchOddDto, MatchOdd>().ReverseMap();
            CreateMap<MatchOddDto, MatchOdd>().ReverseMap();

            #endregion
        }
    }
}