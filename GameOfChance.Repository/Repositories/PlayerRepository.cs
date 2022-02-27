using GameOfChance.Models.DomainModels;
using GameOfChance.Repository.DbContexts.PlayerDbContext;
using GameOfChance.Repository.IRepositories;

namespace GameOfChance.Repository.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IPlayerDbContext context) : base(context)
        {
        }
    }
}
