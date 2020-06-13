using System;
using People;
using static Database.Repository;
using static SystemWideOperations.Parsing;

namespace Birthday
{
    public class Calculate
    {
        public static int DateCountdown(string id)
        {
            return new Func<int>(() => { return CalculateDays(SearchPerson(StringToInt(id)[0],peopleFromTextFile)); })();
        }

        private static int CalculateDays(Person person)
        {
            var nextBirthday = person.Birthday.AddYears(DateTime.Today.Year - person.Birthday.Year);
            if (nextBirthday < DateTime.Today) { nextBirthday = nextBirthday.AddYears(1); }
            return (nextBirthday - DateTime.Today).Days;
        }
    }
}
