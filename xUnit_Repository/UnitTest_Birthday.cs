using Xunit;
using People;
using System;
using static Birthday.Today;
using static Birthday.Calculate;
using System.Collections.Generic;
using static SupportFunctions.RandomData;

namespace xUnit_Birthday
{
    public class UnitTest_Birthday
    {
        [Fact]
        public void DateCountdown_BirthdayToday_Calculate()
        {
            var birthdayList = new List<Person>
            {
                new Person(0, "Name", "Surname", DateTime.Now)
            };
            Assert.Equal(0, DateCountdown("0", birthdayList));
        }

        [Fact]
        public void DateCountdown_BirthdayYesterday_Calculate()
        {
            var birthdayList = new List<Person>
            {
                new Person(0, "Name", "Surname", (DateTime.Now).AddDays(-1))
            };
            var result = DateCountdown("0", birthdayList) >= 364 && DateCountdown("0", birthdayList) <= 366;
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(100)]
        [InlineData(200)]
        public void DateCountdown_BirthdayFuture_Calculate(int days)
        {
            var birthdayList = new List<Person>
            {
                new Person(0, "Name", "Surname", (DateTime.Now).AddDays(days))
            };
            var result = DateCountdown("0", birthdayList) < 364;
            Assert.True(result);
        }


        [Theory, MemberData(nameof(PeopleList))]
        public void CalculateDays_Calculate(int id, string firstName, string surname, DateTime birthday)
        {
            var result = new List<bool>();
            for (var i = 0; i < 10; i++)
            {
                var matchResult = Math.Abs((birthday - DateTime.Today).Days);
                var days = CalculateDays(new Person(id, firstName, surname, birthday));
                result.Add(matchResult == days);
            }
            var ok = 0;
            foreach (var r in result) { if (r == true) { ok++; } }
            Assert.Equal(10, ok);
        }

        public static IEnumerable<object[]> PeopleList
        {
            get
            {
                return new[]
                {
                    new object[] { 0,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(10) },
                    new object[] { 1,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(21) },
                    new object[] { 2,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(32) },
                    new object[] { 3,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(43) },
                    new object[] { 4,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(54) },
                    new object[] { 5,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(65) },
                    new object[] { 6,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(76) },
                    new object[] { 7,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(87) },
                    new object[] { 8,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(98) },
                    new object[] { 9,$"{names[RandomInt(0,4)]}", $"{surnames[RandomInt(0, 4)]}", DateTime.Now.AddDays(100) },
                };
            }
        }

        [Fact]
        public void ReturnResult_BirthdayPeopleOfTheDay_Today()
        {
            var resultList = new List<Person>
            {
                new Person(0, "Name", "Surname", DateTime.Now)
            };
            Assert.DoesNotContain("no person celebrating", BirthdayPeopleOfTheDay(resultList));
        }

        [Fact]
        public void DontReturnResult_BirthdayPeopleOfTheDay_Today()
        {
            var noResultList = new List<Person>
            {
                new Person(0, "Name", "Surname", new DateTime(1234,12,21))
            };
            Assert.Contains("no person celebrating", BirthdayPeopleOfTheDay(noResultList));
        }
    }
}
