using Samples.ApplicationLayer.Organizations;
using System;
using System.Collections.Generic;

namespace Samples.ApplicationLayer.Persons
{
    public interface IPersonDto
    {
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the users first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the last four digits.
        /// </summary>
        int LastFourDigits { get; set; }

        /// <summary>
        /// Gets or sets the users last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mail.
        /// </summary>
        string MailAddress { get; set; }

        /// <summary>
        /// Gets or sets the organizations the person belongs to.
        /// </summary>
        IEnumerable<IOrganizationDto> Organizations { get; set; }
    }
}