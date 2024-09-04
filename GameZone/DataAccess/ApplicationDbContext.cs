using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.DataAccess
{

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "NeedForSpeed",Description="Racing", Level="Hard"},
                new Game { Id = 2, Name = "Pubg", Description = "Fighting", Level = "Amuture" },
                new Game { Id = 3, Name = "Fifa", Description = "Football", Level = "Easy to Legandary" }
                );

        }
        }
}
