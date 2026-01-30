using Microsoft.EntityFrameworkCore;

namespace LANOrganizer.Data
{
    public class LanorgDbContext : DbContext
    {
        public LanorgDbContext(DbContextOptions<LanorgDbContext> options) : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Game> Games { get; set; }
        public DbSet<Models.UserGames> UserGames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.UserGames>()
                .HasKey(ug => ug.Id);
            modelBuilder.Entity<Models.UserGames>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.Games)
                .HasForeignKey(ug => ug.UserId);
            modelBuilder.Entity<Models.UserGames>()
                .HasOne(ug => ug.Game)
                .WithMany(g => g.Owners)
                .HasForeignKey(ug => ug.GameId);
        }
    }
}
