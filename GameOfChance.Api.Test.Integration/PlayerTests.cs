using GameOfChance.Api.Test.Integration.Infrastructure;
using GameOfChance.Models;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace GameOfChance.Api.Test.Integration
{
    public class PlayerTests : IntegrationTestBase
    {
        public PlayerTests(IntegrationTestFixture integrationTestFixture, ITestOutputHelper output) : base(integrationTestFixture, output)
        {
        }

        // NOTE: I am just writing the Unit test to verify the functionality of the endpoint as supposed that the endpoint is authorized.
        // Omitting the Unit tests for authentication and authorization.
        // Here we can call all the other endpoint(Get, ById or Save etc) to verify the behaviour 

        [Fact]
        public async void VerifyTheControllerEndPointWithOutToken_ItShouldReturn_Unauthorized()
        {
            //Setup
            var betRequest = new BetRequest
            {
                Points = 100,
                Number = 3
            };
            var getPlayerRequest = NewRequest

                .AddRoute("api/Player/PlayerStatusByBet");

            // Exercise
            var result = await getPlayerRequest.Post(betRequest);
            // Verify
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);

        }

    }
}