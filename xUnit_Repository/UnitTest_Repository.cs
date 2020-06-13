using Xunit;
using System;
using People;
using Database;
using System.Collections.Generic;
using static SupportFunctions.RandomData;

namespace xUnit_Repository
{
    // WHERE:
    // C = Create_AddPersonToList() equals to 'string AddPerson(Person person)' on Repository.cs
    // R = Read_ReadPeople() equals to 'IEnumerable<Person> ReadPeople()' on Repository.cs
    // U = Update () equals to 'string UpdatePerson(Person person, int id)' on Repository.cs
    // D = Delete() equals to 'string DeletePerson(int id)' on Repository.cs

    public class UnitTest_Repository
    {
        public static List<Person> xUnit_peopleFromTextFile = new List<Person>();
        Repository repository = new Repository();

        [Fact]
        public void Create_AddPersonToList()
        {
            for (var p = 0; p < 5; p++)
            {
                Assert.Contains("\nPerson added.", repository.AddPerson(new Person(
                                                                              p,
                                                                              $"{names[RandomInt(0,4)]}",
                                                                              $"{surnames[RandomInt(0,4)]}",
                                                                              RandomDate()), 
                                                                              xUnit_peopleFromTextFile));
            }
        }

        [Fact]
        public void Read_ReadPeople()
        {
            Assert.NotNull(repository.ReadPeople(xUnit_peopleFromTextFile));
        }

        [Fact]
        public void Update_UpdatePerson()
        {
            var testList = new List<Person>();
            for (var i = 0; i < 5; i++) { testList.Add(new Person(i, "Name", "Surname", new DateTime(2020, 6, 12))); }
            //Create_AddPersonToList();
            var id = RandomInt(0, 4);
            var p = new Person(id, $"NewFirstName",
                                   $"NewSurname", RandomDate());
            Assert.Contains("Contact", repository.UpdatePerson(p, id, testList));
        }

        [Fact]
        public void Delete_DeletePerson()
        {
            Assert.Contains("deleted", repository.DeletePerson(RandomInt(0, 4), xUnit_peopleFromTextFile));
        }
    }
}
