using AutoMapper;
using BetMachine.Domain.Dtos;
using BetMachine.Domain.Interfaces;
using BetMachine.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Match = BetMachine.Domain.Models.Match;

namespace BetMachine.Controllers
{
    /// <summary>
    /// Controller for matches with CRUD operations 
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    public class MatchController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController(unitOfWork, mapper)
    {
        #region HTTP Methods

        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetMatch")]
        public async Task<ActionResult<ServiceResponse<MatchDto>>> GetMatch([FromQuery] int id)
        {
            var response = new ServiceResponse<MatchDto>
            {
                Data = Mapper.Map<MatchDto>(await UnitOfWork.Matches.GetAsync(id))
            };
            response.Success = response.Data is not null;
            if (response.Success) return Ok(response);
            response.Messages.Add(new()
            {
                Code = 1000,
                Message = "Match not found.",
            });
            return NotFound(response);
        }

        /// <summary>
        /// Post Method
        /// </summary>
        /// <param name="matchDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddMatch")]
        public async Task<ActionResult<ServiceResponse<int>>> AddMatch([FromBody] AddMatchDto matchDto)
        {
            var response = new ServiceResponse<int>();
            var match = Mapper.Map<Match>(matchDto);
            await UnitOfWork.Matches.AddAsync(match);
            response.Success = await UnitOfWork.CompleteAsync() > 0 &&
                               match.Id > 0;
            response.Data = match.Id;
            return Ok(response);
        }

        /// <summary>
        /// Put Method
        /// </summary>
        /// <param name="matchDto"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateMatch")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateMatch([FromBody] MatchDto matchDto)
        {
            var response = new ServiceResponse<bool>();
            //Check if match exists 
            if (!await UnitOfWork.Matches.AnyAsync(m => m.Id == matchDto.Id))
            {
                response.Messages.Add(new()
                {
                    Code = 1000,
                    Message = "Match not found.",
                });
                return NotFound(response);
            }

            UnitOfWork.Matches.Update(Mapper.Map<Match>(matchDto));
            response.Success = await UnitOfWork.CompleteAsync() > 0;
            response.Data = response.Success;
            return Ok(response);
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteMatch")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMatch([FromQuery] int id)
        {
            var response = new ServiceResponse<bool>();
            var match = await UnitOfWork.Matches.SingleOrDefaultAsync(m => m.Id == id);

            if (match is null)
            {
                response.Messages.Add(new()
                {
                    Code = 1000,
                    Message = "Match not found.",
                });
                return NotFound(response);
            }

            UnitOfWork.Matches.Delete(match);
            response.Success = await UnitOfWork.CompleteAsync() > 0;
            response.Data = response.Success;
            return Ok(response);
        }

        #endregion
    }
}