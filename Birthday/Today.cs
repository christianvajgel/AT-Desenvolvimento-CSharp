using People;
using System;
using System.Linq;
using System.Collections.Generic;
using static Database.Repository;

namespace Birthday
{
    public class Today
    {
        public static string BirthdayPeopleOfTheDay()
        {
            var resultString = $"\nBirthday people of {DateTime.Today.ToLongDateString()}:\n";
            IEnumerable<Person> result = (
                from person in peopleFromTextFile
                where person.Birthday.Day == DateTime.Today.Day && person.Birthday.Month == DateTime.Today.Month
                select person
                );
            foreach (var person in result)
            {
                var plural = (DateTime.Today.Year - person.Birthday.Year != 1) ? "years" : "year";
                resultString += $"\n - {person.FirstName} {person.Surname} :: {DateTime.Today.Year - person.Birthday.Year} {plural} old\n";
            }
            return !result.Any() ? $"\n{resultString}\n - There is no person celebrating birthday today." : resultString;
        }
    }
}
