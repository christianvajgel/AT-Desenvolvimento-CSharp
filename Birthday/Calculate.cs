using System;
using System.Collections.Generic;
using People;
using static Database.Repository;
using static SystemWideOperations.Parsing;

namespace Birthday
{
    public class Calculate
    {
        // xUnit [Fact] DateCountdown_BirthdayToday_Calculate()
        //              DateCountdown_BirthdayYesterday_Calculate()
        //              DateCountdown_BirthdayFuture_Calculate(int days)
        public static int DateCountdown(string id, List<Person> peopleFromTextFile)
        {
            return new Func<int>(() => { return CalculateDays(SearchPerson(StringToInt(id)[0],peopleFromTextFile)); })();
        }

        // xUnit [Fact] CalculateDays_Calculate(int id, string firstName, string surname, DateTime birthday)
        public static int CalculateDays(Person person)
        {
            var nextBirthday = person.Birthday.AddYears(DateTime.Today.Year - person.Birthday.Year);
            if (nextBirthday < DateTime.Today) { nextBirthday = nextBirthday.AddYears(1); }
            return (nextBirthday - DateTime.Today).Days;
        }
    }
}
