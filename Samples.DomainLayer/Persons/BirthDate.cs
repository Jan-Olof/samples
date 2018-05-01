using System;

namespace Samples.DomainLayer.Persons
{
    public class BirthDate
    {
        private readonly DateTime _now;

        public BirthDate(DateTime dateOfBirth, DateTime now)
        {
            _now = now;

            ValidateAge(dateOfBirth, now);

            Date = dateOfBirth;
        }

        public int Age => CurrentAge(Date, _now);

        public DateTime Date { get; }

        public static int CurrentAge(DateTime dateOfBirth, DateTime now)
        {
            int age = now.Year - dateOfBirth.Year;

            if (now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;
        }

        private static void ValidateAge(DateTime dateOfBirth, DateTime now)
        {
            if (dateOfBirth > now)
            {
                throw new ArgumentException("Birthday is never after the current time.");
            }

            if (CurrentAge(dateOfBirth, now) > 130)
            {
                throw new ArgumentException("Only people that are alive are allowed.");
            }
        }
    }
}