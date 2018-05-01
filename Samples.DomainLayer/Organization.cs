using Samples.DomainLayer.Persons;
using System;
using System.Collections.Generic;

namespace Samples.DomainLayer
{
    /// <summary>
    /// The organization domain class.
    /// NOTE: The is an example for a fictitious domain. Do not use!
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Gets or sets the id. The primary key.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the persons belonging to an organization.
        /// </summary>
        public IEnumerable<Person> Persons { get; set; }
    }
}