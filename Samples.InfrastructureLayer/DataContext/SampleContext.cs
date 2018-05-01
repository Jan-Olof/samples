using Microsoft.EntityFrameworkCore;
using Samples.InfrastructureLayer.OrganizationPersons;
using Samples.InfrastructureLayer.Organizations;
using Samples.InfrastructureLayer.Persons;

namespace Samples.InfrastructureLayer.DataContext
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
        }

        public DbSet<OrganizationPersonDao> OrganizationPersons { get; set; }

        public DbSet<OrganizationDao> Organizations { get; set; }

        public DbSet<PersonDao> Persons { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            string connection = "Server=(localdb)\\mssqllocaldb;Database=Samples;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationPersonConfiguration());
        }
    }
}