using CursusInzicht.DataAcces.Configurations;
using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CursusInzicht.DataAcces
{
    public class CursusInzichtContext : DbContext
    {
        public DbSet<Cursus> Cursussen { get; set; }
        public DbSet<CursusInstantie> CursusInstanties{ get; set; }
    
        public CursusInzichtContext() { }
        public CursusInzichtContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                base.OnConfiguring(optionsBuilder);
                var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json");
                var configuration = builder.Build();

                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("CursusInzichtDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Cursus>(new CursusConfiguration());
            modelBuilder.ApplyConfiguration<CursusInstantie>(new CursusInstantieConfiguratie());
        }
    }
}
