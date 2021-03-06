using GameOfChance.Common;
using GameOfChance.Models;
using GameOfChance.Repository.IRepositories;
using GameOfChance.Service.IServices;

namespace GameOfChance.Service.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<BetResponse> PlayerBetResponse(BetRequest betRequest)
        {
            // Generate the random numbers

            var random = new Random();
            int randomItemNumber = random.Next(0, 10);
            PlayerAccount? domainModel;
            if (randomItemNumber == betRequest.Number)
            {
                // Get the starting account value
                // If number matched then return the multiple of 9
                var accountBalance = Constants.MinAccountBalance + betRequest.Points * Constants.BonusPointTimesBy;
                betRequest.Points = betRequest.Points * Constants.BonusPointTimesBy;
                domainModel = betRequest.Map(accountBalance, true);

            }
            else
            {
                // Player will have the Minimum 10,000 account balance at any case.
                // Should we minus the points in case of lost from the minimum account balance?
                // We can get the record based on the requested ID and can calculate the account balance as well. All the methods written(Get, Update etc)
                var accountBalance = Constants.MinAccountBalance;
                domainModel = betRequest.Map(accountBalance, false);
            }
            // TODO: Here we can also apply the check either the same player already exists in the system or not?
            // For now Inersting the record everytime to consider as new request.

            await _playerRepository.Insert(domainModel);
            return domainModel.Map();
        }
    }
}
