using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapExplore.Models
{
    public class MapExploreDbContext : DbContext
    {
        public MapExploreDbContext()
        {

        }

        public DbSet<Brewery> Breweries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MapExplore;integrated security=True");
        }

        public MapExploreDbContext(DbContextOptions<MapExploreDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
