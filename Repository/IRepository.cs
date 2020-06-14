using People;
using System.Collections.Generic;

namespace Database
{
    public interface IRepository
    {
        string AddPerson(Person person, List<Person> peopleFromTextFile); // CREATE
        IEnumerable<Person> ReadPeople(List<Person> peopleFromTextFile); // READ
        string UpdatePerson(Person person, int id, List<Person> peopleFromTextFile); // UPDATE
        string DeletePerson(int id, List<Person> peopleFromTextFile); // DELETE
        List<Person> SearchPeople(string termFirstName, string termSurname, List<Person> peopleFromTextFile); // Search for keywords
    }
}
