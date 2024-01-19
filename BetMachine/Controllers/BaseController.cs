using AutoMapper;
using BetMachine.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetMachine.Controllers
{
    /// <summary>
    /// Default controller that injects with DI services for all controller that inherit from. 
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; } = unitOfWork;
        public IMapper Mapper { get; } = mapper;
    }
}