using GameOfChance.API.ActionFilters;
using GameOfChance.API.Validators;
using GameOfChance.Models;
using GameOfChance.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GameOfChance.API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost("PlayerStatusByBet"), ValidateModel("betRequest", typeof(BetRequestValidator))]
        public async Task<IActionResult> PlayerStatusByBet([FromBody] BetRequest betRequest)
        {
            SetNewValues(betRequest);
            var result = await _playerService.PlayerBetResponse(betRequest);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
