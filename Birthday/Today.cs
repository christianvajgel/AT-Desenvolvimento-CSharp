using People;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Birthday
{
    public class Today
    {
        // xUnit [Fact] ReturnResult_BirthdayPeopleOfTheDay_Today()
        //              DontReturnResult_BirthdayPeopleOfTheDay_Today()
        public static string BirthdayPeopleOfTheDay(List<Person> peopleFromTextFile)
        {
            var resultString = $"\nBirthday people of {DateTime.Today.ToLongDateString()}:\n";
            IEnumerable<Person> result = (
                                           from person in peopleFromTextFile
                                           where person.Birthday.Day == DateTime.Today.Day &&
                                                 person.Birthday.Month == DateTime.Today.Month
                                           select person
                                            );
            foreach (var person in result)
            {
                var difference = DateTime.Today.Year - person.Birthday.Year;
                var plural = (difference > 0 && difference != 1) ? "years" : "year";
                resultString += $"\n - {person.FirstName} {person.Surname} :: " +
                                $"{DateTime.Today.Year - person.Birthday.Year} {plural} old\n";
            }
            return !result.Any() ? $"\n{resultString}\n - There is no person celebrating birthday today." : resultString;
        }
    }
}
