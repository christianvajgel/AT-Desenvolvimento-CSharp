using System;

namespace People
{
    public class Person
    {
        public Person() { }

        public Person(int id, string firstName, string surnameName, DateTime birthday)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Surname = surnameName ?? throw new ArgumentNullException(nameof(surnameName));
            Birthday = birthday;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }
    }
}
