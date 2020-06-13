using Xunit;
using static Database.TextFile;

namespace xUnit_TextFile
{
    public class UnitTest_TextFile
    {
        [Fact]
        public void CheckCurrentId_TextFile() 
        {
            Assert.IsType<int>(CheckCurrentId());
        }

        [Fact]
        public void GetFileName_TextFile() 
        {
            Assert.Contains("people.txt", GetFileName());
        }

        [Fact]
        public void Create_Read_TextFile() 
        {
            Assert.True(ReadTextFile());
        }

        [Fact]
        public void Close_TextFile() 
        {
            Assert.True(CloseTextFile());
        }
    }
}
