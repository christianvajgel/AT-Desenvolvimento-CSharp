using Xunit;
using People;
using static SupportFunctions.RandomData;

namespace xUnit_Repository
{
    public class UnitTest_Person
    {
        [Fact]
        public void CreateValidPersonObject()
        {
            var person = new Person(RandomInt(0, 10), names[RandomInt(0, 4)], surnames[RandomInt(0, 4)], RandomDate());
            Assert.NotNull(person);
        }
    }
}
