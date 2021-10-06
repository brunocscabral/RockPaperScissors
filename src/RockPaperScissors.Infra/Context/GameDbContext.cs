using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Business.Models;

namespace RockPaperScissors.Infra.Context
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base (options) { }

        public DbSet<Move> Moves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
