using System;

namespace Samples.InfrastructureLayer.Persons
{
    /// <summary>
    /// A class to use when creating a person.
    /// </summary>
    public class CreatePersonDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePersonDto"/> class.
        /// </summary>
        public CreatePersonDto()
        {
            MailAddress = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the users first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last four digits.
        /// </summary>
        public int LastFourDigits { get; set; }

        /// <summary>
        /// Gets or sets the users last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mail.
        /// </summary>
        public string MailAddress { get; set; }
    }
}