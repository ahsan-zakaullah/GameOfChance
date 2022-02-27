using GameOfChance.Models.RequestModels;
using GameOfChance.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GameOfChance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet("PlayerStatusByBet")]
        public IActionResult PlayerStatusByBet([FromQuery] BetRequest betRequest)
        {
            var result = _playerService.PlayerBetResponse(betRequest);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
