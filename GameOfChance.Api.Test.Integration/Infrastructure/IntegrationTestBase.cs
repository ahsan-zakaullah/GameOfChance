using Xunit;
using Xunit.Abstractions;
using GameOfChance.Api.Test.Integration.Utilities;
using GameOfChance.Repository.DbContexts.PlayerDbContext;

namespace GameOfChance.Api.Test.Integration.Infrastructure
{
    [Collection("Integration Tests for DB")]
    public class IntegrationTestBase : IClassFixture<IntegrationTestFixture>
    {
        protected ITestOutputHelper Output { get; }
        protected IPlayerDbContext? DbContext { get; }

        private IntegrationTestFixture _fixture;
        protected IntegrationTestBase(IntegrationTestFixture integrationTestFixture, ITestOutputHelper output)
        {
            Output = output;
            _fixture = integrationTestFixture;
            DbContext = integrationTestFixture.DbContext;
            _fixture = integrationTestFixture;

            if (DbContext != null)
            {
                DbContext.Database.EnsureDeleted();
                DbContext.Database.EnsureCreated();
            }
        }

        public RequestBuilder NewRequest => new RequestBuilder(_fixture.HttpClient);
    }
}
