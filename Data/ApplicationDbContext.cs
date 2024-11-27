using Cezo.API.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace Cezo.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints

            // Artist -> Songs (One-to-Many)
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when an artist is deleted

            // Song -> Comments (One-to-Many)
            modelBuilder.Entity<Song>()
                .HasMany(s => s.Comments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when a song is deleted
        }

    }
}
