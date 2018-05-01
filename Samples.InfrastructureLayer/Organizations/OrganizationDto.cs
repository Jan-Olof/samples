using Samples.ApplicationLayer.Organizations;
using Samples.ApplicationLayer.Persons;
using System;
using System.Collections.Generic;

namespace Samples.InfrastructureLayer.Organizations
{
    public class OrganizationDto : IOrganizationDto
    {
        /// <summary>
        /// Gets or sets the id. The primary key.
        /// </summary>
        public Guid Id { get; set; }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public IEnumerable<IPersonDto> Persons { get; set; }
    }
}