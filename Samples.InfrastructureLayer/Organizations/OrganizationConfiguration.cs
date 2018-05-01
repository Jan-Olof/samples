using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Samples.InfrastructureLayer.Organizations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<OrganizationDao>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<OrganizationDao> builder)
            => builder.HasKey(organizationDao => organizationDao.Id);
    }
}