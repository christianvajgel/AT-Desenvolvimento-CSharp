using People;
using System;
using System.Collections.Generic;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Parsing;
using static SystemWideOperations.Validations;

namespace Input
{
    public class Dates
    {
        public static DateTime GetDate(List<Person> resultList)
        {
            var completeDate = "";
            var finalDate = new DateTime();
            do
            {
                var day = Numbers.ReadNumber("day", resultList);
                var month = Numbers.ReadNumber("month", resultList);
                var year = Numbers.ReadNumber("year", resultList);
                completeDate = year + "/" + month + "/" + day;
                if (DateValidation(completeDate) == default)
                {
                    Console.WriteLine("Invalid date.\nTry again.");
                    ClearScreen(false);
                }
                else
                {
                    finalDate = ConvertToDateTimeObject(day, month, year)[0];
                }
            } while (DateValidation(completeDate) == default);
            return finalDate;
        }
    }
}
