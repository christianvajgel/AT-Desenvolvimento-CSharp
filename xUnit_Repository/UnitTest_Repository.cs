using Xunit;
using System;
using People;
using Database;
using static Database.Repository;
using System.Collections.Generic;
using static SupportFunctions.RandomData;

namespace xUnit_Repository
{
    // WHERE:
    // C = Create_AddPersonToList() equals to 'string AddPerson(Person person)' on Repository.cs
    // R = Read_ReadPeople() equals to 'IEnumerable<Person> ReadPeople()' on Repository.cs
    // U = Update_UpdatePerson() equals to 'string UpdatePerson(Person person, int id)' on Repository.cs
    // D = Delete_DeletePerson() equals to 'string DeletePerson(int id)' on Repository.cs

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
                                                                                    $"{names[RandomInt(0, 4)]}",
                                                                                    $"{surnames[RandomInt(0, 4)]}",
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

        [Fact]
        public void ReorganizeListObjectsIndex_Repository()
        {
            var p = new Person(1, $"{names[RandomInt(0, 4)]}", $"{surnames[RandomInt(0, 4)]}", RandomDate());
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                p
            };
            list.Remove(p);
            ReorganizeListObjectsIndex(1, list);
            Assert.Equal(0, list.Count - 1);
        }

        [Fact]
        public void SearchPeople_SingleResult_Repository()
        {
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(3, $"Name",$"Surname",RandomDate())
            };
            var result = repository.SearchPeople("Name", "Surname", list);
            Assert.Single(result);
        }

        [Fact]
        public void SearchPeople_MultipleResults_Repository()
        {
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"NameOne",$"SurnameOne",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(3, $"NameTwo",$"SurnameTwo",RandomDate()),
                new Person(4, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(5, $"NameThree",$"SurnameThree",RandomDate())
            };
            var result = repository.SearchPeople("Name", "Surname", list);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void SearchPerson_Repository()
        {
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(3, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(4, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(5, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate())
            };
            Assert.NotNull(SearchPerson(2, list));
        }

        [Fact]
        public void PersonFullName()
        {
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(3, $"Name",$"Surname",RandomDate()),
                new Person(4, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(5, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate())
            };
            Assert.Equal("Name Surname", repository.PersonFullName("3", list));
        }

        [Fact]
        public void CheckContactExistence_Repository()
        {
            var person = new Person(2, $"{names[RandomInt(0, 4)]}", $"{surnames[RandomInt(0, 4)]}", RandomDate());
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                person,
                new Person(3, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
            };
            Assert.True(CheckContactExistence(person, list));
        }

        [Fact]
        public void GenerateList_Repository()
        {
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate())
            };
            Assert.NotEqual(String.Empty, GenerateList(repository, list));
        }
    }
}
