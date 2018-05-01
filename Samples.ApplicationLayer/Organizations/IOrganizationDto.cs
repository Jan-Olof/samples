using Samples.ApplicationLayer.Persons;
using System;
using System.Collections.Generic;

namespace Samples.ApplicationLayer.Organizations
{
    public interface IOrganizationDto
    {
        /// <summary>
        /// Gets or sets the id. The primary key.
        /// </summary>
        Guid Id { get; set; }

        string Name { get; set; }

        IEnumerable<IPersonDto> Persons { get; set; }
    }
}