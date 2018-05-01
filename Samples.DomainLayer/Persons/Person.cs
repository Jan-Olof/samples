using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Samples.DomainLayer.Persons
{
    /// <summary>
    /// The person domain class.
    /// NOTE: The is an example for a fictitious domain. Do not use!
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets a persons date of birth.
        /// </summary>
        public BirthDate DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the persons id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the last four digits.
        /// </summary>
        public int LastFourDigits { get; set; }

        /// <summary>
        /// Gets or sets the mail.
        /// </summary>
        public MailAddress MailAddress { get; set; }

        /// <summary>
        /// Gets or sets the persons name.
        /// </summary>
        public PersonsName Name { get; set; }

        /// <summary>
        /// Gets or sets the organizations the person belongs to.
        /// </summary>
        public IEnumerable<Organization> Organizations { get; set; }
    }
}