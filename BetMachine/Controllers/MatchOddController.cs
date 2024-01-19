using AutoMapper;
using BetMachine.Domain.Dtos;
using BetMachine.Domain.Interfaces;
using BetMachine.Domain.Models;
using BetMachine.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace BetMachine.Controllers
{
    #region HTTP Methods

    /// <summary>
    /// Controller for match odds with CRUD operations 
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    public class MatchOddController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController(unitOfWork, mapper)
    {
        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetMatchOdd")]
        public async Task<ActionResult<ServiceResponse<MatchOdd>>> GetMatchOdd([FromQuery] int id)
        {
            var response = new ServiceResponse<MatchOddDto>
            {
                Data = Mapper.Map<MatchOddDto>(await UnitOfWork.MatchOdds.GetAsync(id))
            };
            response.Success = response.Data is not null;
            if (response.Success) return Ok(response);
            response.Messages.Add(new()
            {
                Code = 2000,
                Message = "Match Odd not found.",
            });
            return NotFound(response);
        }

        /// <summary>
        /// Post Method
        /// </summary>
        /// <param name="addMatchOddDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddMatchOdd")]
        public async Task<ActionResult<ServiceResponse<int>>> AddMatchOdd([FromBody] AddMatchOddDto addMatchOddDto)
        {
            var response = new ServiceResponse<int>();
            //Check if match exists
            if (!await UnitOfWork.Matches.AnyAsync(m => m.Id == addMatchOddDto.MatchId))
            {
                response.Messages.Add(new()
                {
                    Code = 2001,
                    Message = "Match not found.Please insert match first.",
                });
                return NotFound(response);
            }

            var match = Mapper.Map<MatchOdd>(addMatchOddDto);
            await UnitOfWork.MatchOdds.AddAsync(match);
            response.Success = await UnitOfWork.CompleteAsync() > 0 &&
                               match.Id > 0;
            response.Data = match.Id;
            return Ok(response);
        }

        /// <summary>
        /// Put Method
        /// </summary>
        /// <param name="matchOdd"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateMatchOdd")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateMatchOdd([FromBody] MatchOddDto matchOdd)
        {
            //TODO allow to change match???
            var response = new ServiceResponse<bool>();

            //Check if updated match exists
            if (!await UnitOfWork.Matches.AnyAsync(m => m.Id == matchOdd.MatchId))
            {
                response.Messages.Add(new()
                {
                    Code = 2001,
                    Message = "Match not found.Please insert match first.",
                });
                return NotFound(response);
            }

            //Check if odd exists
            var found = await UnitOfWork.MatchOdds.AnyAsync(m => m.Id == matchOdd.Id);
            if (!found)
            {
                response.Messages.Add(new()
                {
                    Code = 2000,
                    Message = "Match Odd not found.",
                });
                return NotFound(response);
            }

            UnitOfWork.MatchOdds.Update(Mapper.Map<MatchOdd>(matchOdd));
            response.Success = await UnitOfWork.CompleteAsync() > 0;
            response.Data = response.Success;
            return Ok(response);
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteMatchOdd")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMatchOdd([FromQuery] int id)
        {
            var response = new ServiceResponse<bool>();
            //Check if odd exists
            var match = await UnitOfWork.MatchOdds.SingleOrDefaultAsync(m => m.Id == id);
            if (match is null)
            {
                response.Messages.Add(new()
                {
                    Code = 2000,
                    Message = "Match Odd not found.",
                });
                return NotFound(response);
            }

            UnitOfWork.MatchOdds.Delete(match);
            response.Success = await UnitOfWork.CompleteAsync() > 0;
            response.Data = response.Success;
            return Ok(response);
        }

        #endregion
    }
}