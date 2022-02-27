using GameOfChance.Models.RequestModels;
using GameOfChance.Models.ResponseModels;

namespace GameOfChance.Service.IServices
{
    public interface IPlayerService
    {
        public Task<BetResponse> PlayerBetResponse(BetRequest betRequest);
    }
}
