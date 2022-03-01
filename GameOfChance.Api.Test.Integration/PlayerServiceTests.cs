using GameOfChance.Api.Test.Integration.Mocks.Repositories;
using GameOfChance.Common;
using GameOfChance.Models;
using GameOfChance.Service.Services;
using Xunit;

namespace GameOfChance.Api.Test.Integration
{
    public class PlayerServiceTests
    {
        PlayerService? playerService;
        public PlayerServiceTests()
        {
            var mockplayerRepo = new MockPlayerRepository();

            playerService = new PlayerService(mockplayerRepo.Object);
        }

        // Here i am writing the some basics tests to verify the service.
        [Fact]
        public async void VerifyThePlayerPoint_ShouldGetResult()
        {
            //Setup
            var betRequest = new BetRequest
            {
                Points = 100,
                Number = 3
            };
            // Exercise
            var result = await playerService.PlayerBetResponse(betRequest);

            // Verify

            // Need to verify the result should not be null
            Assert.NotNull(result);
        }

        [Fact]
        public async void VerifyThePlayerAccount_ItShouldBeGreaterThan10000_InAnyCase()
        {
            //Setup
            var betRequest = new BetRequest
            {
                Points = 100,
                Number = 3
            };
            // Exercise
            var result = await playerService.PlayerBetResponse(betRequest);
            // Verify

            // Need to verify the result should not be null
            Assert.NotNull(result);
            var expectedResult = Constants.MinAccountBalance;
            Assert.True(result.Account >= expectedResult);
        }
    }
}
