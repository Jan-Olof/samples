namespace Samples.DomainLayer.Persons
{
    public class PersonsName
    {
        public PersonsName(string firstName, string lastName)
        {
            Name = $"{firstName} {lastName}";
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Name { get; }
    }
}