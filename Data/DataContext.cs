using Kolokvijum2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokvijum2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Proizvodjac> Proizvodjaci { get; set; }
        public DbSet<Automobil> Automobili { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvodjac>();
            modelBuilder.Entity<Automobil>();

            modelBuilder.Entity<Proizvodjac>()
                .HasMany(a => a.Automobili)
                .WithOne(p => p.Proizvodjac);
        }
    }
}
