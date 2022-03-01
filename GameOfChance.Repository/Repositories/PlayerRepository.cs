using GameOfChance.Models;
using GameOfChance.Repository.DbContexts.PlayerDbContext;
using GameOfChance.Repository.IRepositories;

namespace GameOfChance.Repository.Repositories
{
    public class PlayerRepository : GenericRepository<PlayerAccount>, IPlayerRepository
    {
        public PlayerRepository(IPlayerDbContext context) : base(context)
        {
        }
    }
}
