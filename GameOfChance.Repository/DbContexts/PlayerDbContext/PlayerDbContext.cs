using GameOfChance.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GameOfChance.Repository.DbContexts.PlayerDbContext
{
    public class PlayerDbContext : DbContext, IPlayerDbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(it => it.Id);

        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}