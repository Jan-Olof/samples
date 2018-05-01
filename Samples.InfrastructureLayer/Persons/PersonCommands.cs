using AutoMapper;
using Samples.ApplicationLayer.Persons;
using Samples.DomainLayer.Persons;
using Samples.InfrastructureLayer.DataContext;
using Samples.InfrastructureLayer.Exceptions;
using System;

namespace Samples.InfrastructureLayer.Persons
{
    public class PersonCommands : Commands, IPersonCommands
    {
        /// <inheritdoc />
        public PersonCommands(SampleContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc />
        public void DeletePerson(Guid id)
        {
            var person = Context.Persons.Find(id);

            if (person == null)
            {
                throw new NotFoundException($"No person with id {id} exists.");
            }

            Context.Remove(person);
        }

        /// <inheritdoc />
        public Person InsertPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            var personDao = Mapper.Map<PersonDao>(person);

            Context.Add(personDao);
            return person;
        }

        /// <inheritdoc />
        public void UpdatePerson(Person person)
        {
            var existingPerson = Context.Persons.Find(person.Id);

            if (existingPerson == null)
            {
                throw new NotFoundException($"No person with id {person.Id} exists.");
            }

            existingPerson.FirstName = person.Name.FirstName;
            existingPerson.LastName = person.Name.LastName;
            existingPerson.DateOfBirth = person.DateOfBirth.Date;
            existingPerson.LastFourDigits = person.LastFourDigits;
            existingPerson.MailAddress = person.MailAddress.Address;
        }
    }
}