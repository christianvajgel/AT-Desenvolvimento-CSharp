using Xunit;
using People;
using Database;
using static Menu.Delete;
using System.Collections.Generic;
using static SupportFunctions.RandomData;

namespace xUnit_Menu
{
    public class UnitTest_Delete
    {
        [Fact]
        public void ShowMenuDeletePeople_Delete()
        {
            var repository = new Repository();
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate())
            };
            Assert.Contains("Delete a person", ShowMenuDeletePeople(repository, list));
        }
    }
}
