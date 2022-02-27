using GameOfChance.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GameOfChance.Repository.DbContexts.PlayerDbContext
{
    public interface IPlayerDbContext : IDbContext
    {
        DbSet<Player> Players { get; set; }
    }
}