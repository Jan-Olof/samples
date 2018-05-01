using Samples.InfrastructureLayer.OrganizationPersons;
using System;
using System.Collections.Generic;

namespace Samples.InfrastructureLayer.Organizations
{
    public class OrganizationDao
    {
        /// <summary>
        /// Gets or sets the id. The primary key.
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<OrganizationPersonDao> OrganizationPersons { get; set; }
    }
}