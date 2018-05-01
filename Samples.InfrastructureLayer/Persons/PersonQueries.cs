using AutoMapper;
using Samples.ApplicationLayer;
using Samples.ApplicationLayer.Persons;
using Samples.InfrastructureLayer.DataContext;
using Samples.InfrastructureLayer.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.InfrastructureLayer.Persons
{
    public class PersonQueries : Queries, IQueries<IPersonDto>
    {
        public PersonQueries(SampleContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc />
        public IPersonDto Get(Guid id)
        {
            var personDao = PersonsWithOrgs.SingleOrDefault(p => p.Id == id);
            return MapOnePerson(personDao);
        }

        /// <inheritdoc />
        public IEnumerable<IPersonDto> GetAll()
            => PersonsWithOrgs.Select(personDao => MapOnePerson(personDao));

        private PersonDto MapOnePerson(PersonDao personDao)
        {
            var organizationDaos = personDao.OrganizationPersons.Select(op => op.Organization);

            var personDto = Mapper.Map<PersonDto>(personDao);
            personDto.Organizations = Mapper.Map<IEnumerable<OrganizationDto>>(organizationDaos);

            return personDto;
        }
    }
}