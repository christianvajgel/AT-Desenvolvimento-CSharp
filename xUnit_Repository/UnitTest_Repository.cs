using System;
using System.Collections.Generic;
using Xunit;
using People;
using static SupportFunctions.RandomData;
using Database;
using SupportFunctions;

namespace xUnit_Repository
{
    // WHERE:
    // C = Create_AddPersonToList() equals to 'string AddPerson(Person person)' on Repository.cs
    // R = Read_ReadPeople() equals to 'IEnumerable<Person> ReadPeople()' on Repository.cs
    // U = Update () equals to 'string UpdatePerson(Person person, int id)' on Repository.cs
    // D = Delete() equals to 'string DeletePerson(int id)' on Repository.cs

    public class UnitTest_Repository
    {
        public static List<Person> peopleFromTextFile = new List<Person>();
        Repository repository = new Repository();

        [Fact]
        public void Create_AddPersonToList()
        {
            for (var p = 0; p < 21; p++) 
            {
                Assert.Equal("Person added.",repository.AddPerson(new Person(
                                                                  p, 
                                                                  $"{RandomData.names[RandomInt(0,4)]}", 
                                                                  $"{RandomData.surnames[RandomInt(0, 4)]}", 
                                                                  RandomDate())));
            }
        }

        [Fact]
        public void Read_ReadPeople() 
        {
            Assert.NotNull(repository.ReadPeople()); 
        }

        [Fact]
        public void Update_UpdatePerson() 
        {
            //Create_AddPersonToList();
            var id = RandomInt(0, 20);
            var p = new Person(id,$"{RandomData.names[RandomInt(0, 4)]}",
                            $"{RandomData.surnames[RandomInt(0, 4)]}",RandomDate());
            Assert.Contains("Contact",repository.UpdatePerson(p, id));
        }

        [Fact]
        public void Delete_DeletePerson() 
        {
            Assert.Contains("deleted",repository.DeletePerson(RandomInt(0, 20)));
        }
    }
}
