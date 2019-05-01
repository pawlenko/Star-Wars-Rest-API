using Microsoft.EntityFrameworkCore;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<Planet> Planet { get; set; }


    }
}
