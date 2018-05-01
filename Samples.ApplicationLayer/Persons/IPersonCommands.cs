using Samples.DomainLayer.Persons;
using System;

namespace Samples.ApplicationLayer.Persons
{
    public interface IPersonCommands
    {
        /// <summary>
        /// Delete a person.
        /// </summary>
        void DeletePerson(Guid id);

        /// <summary>
        /// Create a new person.
        /// </summary>
        Person InsertPerson(Person person);

        /// <summary>
        /// Update an existing person.
        /// </summary>
        void UpdatePerson(Person person);
    }
}