using Samples.ApplicationLayer.Organizations;
using Samples.ApplicationLayer.Persons;
using System.Collections.Generic;

namespace Samples.InfrastructureLayer.Persons
{
    /// <summary>
    /// The person class.
    /// </summary>
    public class PersonDto : CreatePersonDto, IPersonDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDto"/> class.
        /// </summary>
        public PersonDto() => Id = string.Empty;

        /// <inheritdoc />
        public string Id { get; set; }

        /// <inheritdoc />
        public IEnumerable<IOrganizationDto> Organizations { get; set; }
    }
}