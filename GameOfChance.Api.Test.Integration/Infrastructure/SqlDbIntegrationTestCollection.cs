using Xunit;

namespace GameOfChance.Api.Test.Integration.Infrastructure
{
    [CollectionDefinition("SQL Integration Tests")]
    public class SqlDbIntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
    {
    }
}
