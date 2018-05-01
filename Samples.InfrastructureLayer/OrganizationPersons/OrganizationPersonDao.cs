using Samples.InfrastructureLayer.Organizations;
using Samples.InfrastructureLayer.Persons;
using System;

namespace Samples.InfrastructureLayer.OrganizationPersons
{
    public class OrganizationPersonDao
    {
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        public OrganizationDao Organization { get; set; }

        /// <summary>
        /// Gets or sets the organization id.
        /// </summary>
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        public PersonDao Person { get; set; }

        /// <summary>
        /// Gets or sets the person id.
        /// </summary>
        public Guid PersonId { get; set; }
    }
}