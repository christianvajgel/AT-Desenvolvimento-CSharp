using Xunit;
using System;
using System.Collections.Generic;
using static SystemWideOperations.Parsing;

namespace xUnit_Parsing
{
    public class UnitTest_Parsing
    {
        [Theory]
        [InlineData("123")]
        [InlineData("456")]
        [InlineData("789")]
        public void StringToInt_Valid(string evaluate)
        {
            Assert.IsType<int>(StringToInt(evaluate)[0]);
        }

        [Theory]
        [InlineData("string")]
        [InlineData("str1ng")]
        [InlineData("STR1NG")]
        [InlineData("STRING")]
        [InlineData("!@#$%¨&*()")]
        public void StringToInt_NotValid(string evaluate)
        {
            var notValidNumber = StringToInt(evaluate);
            Assert.Null(notValidNumber);
        }

        [Theory]
        [InlineData("11","06","2020")]
        [InlineData("12","07","2021")]
        [InlineData("13","08","2022")]
        public void ConvertToDateTimeObject_Valid(string day, string month, string year)
        {
            Assert.IsType<List<DateTime>>(ConvertToDateTimeObject(day,month,year));
        }

        [Theory]
        [InlineData("98", "76","54321")]
        [InlineData("30","02","2020")]
        [InlineData("31","06","2020")]
        public void ConvertToDateTimeObject_NotValid(string day, string month, string year)
        {
            var notValidDate = ConvertToDateTimeObject(day, month, year);
            Assert.IsNotType<List<DateTime>>(notValidDate);
        }
    }
}
