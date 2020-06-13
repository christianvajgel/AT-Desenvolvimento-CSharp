using System;
using Xunit;
using static SystemWideOperations.Validations;

namespace xUnit_Repository
{
    public class UnitTest_Validations
    {
        [Theory]
        [InlineData("string")]
        public void StringValidation_Valid(string evaluate)
        {
            Assert.Equal("valid",StringValidation(evaluate)[0]);
        }

        [Theory]
        [InlineData("str1ng")]
        [InlineData("123")]
        [InlineData("$tr!n(")]
        public void StringValidation_NotValid(string evaluate)
        {
            Assert.Contains("invalid", StringValidation(evaluate)[0]);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("456")]
        [InlineData("789")]
        public void NumberValidation_Valid(string evaluate)
        {
            Assert.Equal("valid",StringValidation(evaluate)[1]);
        }

        [Theory]
        [InlineData("str1ng")]
        [InlineData("STRING")]
        [InlineData("$tr!n(")]
        public void NumberValidation_NotValid(string evaluate)
        {
            Assert.Contains("integers", StringValidation(evaluate)[1]);
        }

        [Theory]
        [InlineData("2020/06/11")]
        [InlineData("2021/07/12")]
        [InlineData("2022/08/13")]
        public void DateValidation_Valid(string evaluate)
        {
            Assert.IsType<DateTime>(DateValidation(evaluate));
        }
        
        [Theory]
        [InlineData("12345/67/89")]
        [InlineData("2020/02/30")]
        [InlineData("2020/06/31")]
        public void DateValidation_NotValid(string evaluate)
        {
            var notValidDate = DateValidation(evaluate).ToString();
            Assert.Equal("1/1/0001 12:00:00 AM", notValidDate);
        }
    }
}
