using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Samples.InfrastructureLayer.DataContext;

namespace Samples.WebApi
{
    /// <summary>
    /// This is just use for the db design by EF Core.
    /// </summary>
    public class DbContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        /// <inheritdoc />
        public SampleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Samples;Trusted_Connection=True;");

            return new SampleContext(optionsBuilder.Options);
        }
    }
}