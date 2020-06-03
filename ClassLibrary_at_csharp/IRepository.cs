using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_at_csharp
{
    public interface IRepository
    {
        string AddPerson(Person person); // CREATE
        IEnumerable<Person> ReadPeople(); // READ
        string UpdatePerson(Person person, Person updated); // UPDATE
        string DeletePerson(Person person); // DELETE

        IEnumerable<Person> SearchPeople(string termFirstName, string termSurname); // Search for keywords
        IEnumerable<Person> BirthdayPeopleOfTheDay(); // Return people who is celebrating birthday today
    }
}
