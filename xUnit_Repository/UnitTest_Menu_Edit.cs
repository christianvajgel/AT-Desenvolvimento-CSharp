using Xunit;
using People;
using Database;
using static Menu.Edit;
using System.Collections.Generic;
using static SupportFunctions.RandomData;

namespace xUnit_Menu
{
    public class UnitTest_Edit
    {
        [Fact]
        public void ShowMenuEditPeople_Edit() 
        {
            var repository = new Repository();
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate())
            };
            Assert.Contains("Edit a person", ShowMenuEditPeople(repository, list));
        }

        [Fact]
        public void ShowPersonToEdit_Edit()
        {
            var repository = new Repository();
            var list = new List<Person>
            {
                new Person(0, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(1, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate()),
                new Person(2, $"{names[RandomInt(0,4)]}",$"{surnames[RandomInt(0,4)]}",RandomDate())
            };
            Assert.Contains("- - - - -", ShowPersonToEdit(2, repository, list));
        }
    }
}
