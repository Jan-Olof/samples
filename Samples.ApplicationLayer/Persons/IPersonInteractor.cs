using Samples.DomainLayer.Persons;
using System;

namespace Samples.ApplicationLayer.Persons
{
    /// <summary>
    /// The person interactor interface.
    /// </summary>
    public interface IPersonInteractor
    {
        /// <summary>
        /// Create a new person.
        /// </summary>
        Person CreatePerson(Person person);

        /// <summary>
        /// Edit an existing person.
        /// </summary>
        void EditPerson(Person person);

        /// <summary>
        /// Remove an existing person.
        /// </summary>
        void RemovePerson(Guid id);
    }
}