using AutoMapper;
using Samples.ApplicationLayer;
using Samples.ApplicationLayer.Organizations;
using Samples.InfrastructureLayer.DataContext;
using Samples.InfrastructureLayer.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.InfrastructureLayer.Organizations
{
    public class OrganizationQueries : Queries, IQueries<IOrganizationDto>
    {
        /// <inheritdoc />
        public OrganizationQueries(SampleContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc />
        public IOrganizationDto Get(Guid id)
        {
            var organizationDao = OrganizationsWithPersons.SingleOrDefault(o => o.Id == id);
            return MapOneOrganization(organizationDao);
        }

        /// <inheritdoc />
        public IEnumerable<IOrganizationDto> GetAll()
            => OrganizationsWithPersons.Select(organizationDao => MapOneOrganization(organizationDao));

        private OrganizationDto MapOneOrganization(OrganizationDao organizationDao)
        {
            var personDaos = organizationDao.OrganizationPersons.Select(op => op.Person);

            var organizationDto = Mapper.Map<OrganizationDto>(organizationDao);
            organizationDto.Persons = Mapper.Map<IEnumerable<PersonDto>>(personDaos);

            return organizationDto;
        }
    }
}