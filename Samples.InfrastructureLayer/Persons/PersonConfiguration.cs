using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Samples.InfrastructureLayer.Persons
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonDao>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<PersonDao> builder)
            => builder.HasKey(personDao => personDao.Id);
    }
}