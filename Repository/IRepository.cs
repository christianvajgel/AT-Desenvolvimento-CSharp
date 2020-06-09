using System;
using System.Collections.Generic;
using System.Text;
using People;

namespace Database
{
    public interface IRepository
    {
        string AddPerson(Person person); // CREATE
        IEnumerable<Person> ReadPeople(); // READ
        string UpdatePerson(Person person, int id); // UPDATE
        string DeletePerson(int id); // DELETE

        List<Person> SearchPeople(string termFirstName, string termSurname); // Search for keywords
        string BirthdayPeopleOfTheDay(); // Return people who is celebrating birthday today
    }
}
