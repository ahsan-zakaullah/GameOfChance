using GameOfChance.Models;

namespace GameOfChance.Service.IServices
{
    public interface IPlayerService
    {
        public Task<BetResponse> PlayerBetResponse(BetRequest betRequest);
    }
}
