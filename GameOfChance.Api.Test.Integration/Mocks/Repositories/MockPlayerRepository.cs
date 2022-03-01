using GameOfChance.Common;
using GameOfChance.Models;
using GameOfChance.Repository.IRepositories;
using Moq;

namespace GameOfChance.Api.Test.Integration.Mocks.Repositories
{
    public class MockPlayerRepository : Mock<IPlayerRepository>
    {
        // Adding few methods just for reference which can be use while verifying the test cases.
        public MockPlayerRepository MockInsert(int result)
        {
            Setup(x => x.Insert(It.IsAny<PlayerAccount>()))
               .ReturnsAsync(result);

            return this;
        }

        public MockPlayerRepository MockInsertInvalid()
        {
            Setup(x => x.Insert(It.IsAny<PlayerAccount>()))
           .Throws(new GameOfChanceException("Insertion failed."));

            return this;
        }

        public MockPlayerRepository VerifyInsert(Times times)
        {
            Verify(x => x.Insert(It.IsAny<PlayerAccount>()), times);

            return this;
        }
    }
}
