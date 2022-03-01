using GameOfChance.Models;
using Microsoft.EntityFrameworkCore;

namespace GameOfChance.Repository.DbContexts.PlayerDbContext
{
    public interface IPlayerDbContext : IDbContext
    {
        DbSet<PlayerAccount> Players { get; set; }
    }
}