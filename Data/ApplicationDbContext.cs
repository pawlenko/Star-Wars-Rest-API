using Data.Models;
using Microsoft.EntityFrameworkCore;
using SW.Data.Models;

namespace SW.Data
{
  public  class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<CharacterEpisode>()
             .HasKey(bc => new { bc.Id });

            builder.Entity<CharacterEpisode>()
                .HasOne(bc => bc.Character)
                .WithMany(b => b.Episodes)
                .HasForeignKey(bc => bc.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<CharacterEpisode>()
                .HasOne(bc => bc.Episode)
                .WithMany(c => c.Characters)
                .HasForeignKey(bc => bc.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<CharacterEpisode>().HasIndex(e => e.CharacterId).IsUnique(false);
            builder.Entity<CharacterEpisode>().HasIndex(e => e.EpisodeId).IsUnique(false);


            builder.Entity<Friend>()
                .HasOne(e => e.Character)
                .WithMany(e => e.Friends)
                .HasForeignKey(e => e.CharacterId);

            builder.Entity<Friend>()
                .HasOne(e => e.Friends)
                .WithMany(e => e.FriendFor)
                .HasForeignKey(e => e.FriendId);

            base.OnModelCreating(builder);
        }


        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<CharacterEpisode> CharacterEpisode { get; set; }



    }
}