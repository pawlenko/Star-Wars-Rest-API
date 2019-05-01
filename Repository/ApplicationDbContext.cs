using Data.Models;
using Microsoft.EntityFrameworkCore;



namespace SW.Repository
{
  public  class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
        }


        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Planet> Planets { get; set; }

    }
}