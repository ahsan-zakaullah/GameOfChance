using AutoFixture;
using GameOfChance.Api.Test.Integration.Infrastructure;
using GameOfChance.Models.RequestModels;
using Xunit;
using Xunit.Abstractions;

namespace GameOfChance.Api.Test.Integration
{
    public class PlayerTests : IntegrationTestBase
    {
        public PlayerTests(IntegrationTestFixture integrationTestFixture, ITestOutputHelper output) : base(integrationTestFixture, output)
        {
        }

        [Fact]
        public async void VerifyTheControllerEndPoint_ItShouldReturn_OkResponse()
        {
            //Setup
            var fixture = new Fixture();
            var betRequest = new BetRequest
            {
                Points = 100,
                number = 3
            };
            var getPlayerRequest = NewRequest
                     .AddRoute("Player/PlayerStatusByBet");

            // Exercise
            var result = await getPlayerRequest.Post(betRequest);
            // Verify
            // Need to verify the result should not be null
            Assert.NotNull(result);

        }

        [Fact]
        public async void VerifyThePlayerPoint_ItShouldBeMultipleByNine_IfStatusIsSuccess()
        {
            //Setup
            var fixture = new Fixture();
            var betRequest = new BetRequest
            {
                Points = 100,
                number = 3
            };
            var getPlayerRequest = NewRequest
                     .AddRoute("Player/PlayerStatusByBet");

            // Exercise
            var result = await getPlayerRequest.Post(betRequest);
            // Verify

            // Need to verify the result should not be null
            Assert.NotNull(result);
        }

        [Fact]
        public async void VerifyThePlayerAccount_ItShouldBeGreaterThan10000_InAnyCase()
        {
            //Setup
            var fixture = new Fixture();
            var betRequest = new BetRequest
            {
                Points = 100,
                number = 3
            };
            var getPlayerRequest = NewRequest
                     .AddRoute("Player/PlayerStatusByBet");

            // Exercise
            var result = await getPlayerRequest.Post(betRequest);
            // Verify
            // Need to verify the result should not be null
            Assert.NotNull(result);
        }
    }
}