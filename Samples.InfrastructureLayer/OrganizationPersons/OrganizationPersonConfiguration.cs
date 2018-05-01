using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Samples.InfrastructureLayer.OrganizationPersons
{
    public class OrganizationPersonConfiguration : IEntityTypeConfiguration<OrganizationPersonDao>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<OrganizationPersonDao> builder)
        {
            builder
                .HasKey(organizationPersonDao => new { organizationPersonDao.PersonId, organizationPersonDao.OrganizationId });

            builder
                .HasOne(organizationPersonDao => organizationPersonDao.Organization)
                .WithMany(organizationDao => organizationDao.OrganizationPersons)
                .HasForeignKey(organizationPersonDao => organizationPersonDao.OrganizationId);

            builder
                .HasOne(organizationPersonDao => organizationPersonDao.Person)
                .WithMany(personDao => personDao.OrganizationPersons)
                .HasForeignKey(organizationPersonDao => organizationPersonDao.PersonId);
        }
    }
}