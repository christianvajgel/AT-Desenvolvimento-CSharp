using System;
using static SystemWideOperations.Clear;
using static Input.Strings;
using static Input.Numbers;
using People;
using static SystemWideOperations.Parsing;
using static SystemWideOperations.Validations;
using static Input.Dates;
using Database;
using System.Collections.Generic;

namespace Menu
{
    public class Add
    {
        public static Boolean ok_Add;
        public static void AddMenu(Repository repository, List<Person> resultList, int id)
        {
            while (true)
            {
                ok_Add = false;
                Console.WriteLine($"OK (false) : {ok_Add}");
                Console.ReadKey();
                ClearScreen(false);
                ShowMenuAddPeople();

                var firstName = ReadString("firstName");
                var surname = ReadString("surname");
                var birthday = GetDate(resultList);
                //var birthday = new Func<DateTime>(() =>
                //{
                //    var completeDate = "";
                //    var finalDate = new DateTime();
                //    do
                //    {
                //        var day = ReadNumber("day", resultList);
                //        var month = ReadNumber("month", resultList);
                //        var year = ReadNumber("year", resultList);
                //        completeDate = year + "/" + month + "/" + day;
                //        if (DateValidation(completeDate) == default)
                //        {
                //            Console.WriteLine("Invalid date.\nTry again.");
                //            ClearScreen(false);
                //        }
                //        else
                //        {
                //            finalDate = ConvertToDateTimeObject(day, month, year)[0];
                //        }
                //    } while (DateValidation(completeDate) == default);
                //    return finalDate;
                //})();
                //var person = new Person(Guid.NewGuid(), firstName, surname, birthday);
                var person = new Person(id, firstName, surname, birthday);
                var message = repository.AddPerson(person);

                if (message.Equals("Person added.")) { ok_Add = true; Console.WriteLine($"OK (true) : {ok_Add}"); Console.ReadKey(); }
                Console.WriteLine(message);
                ClearScreen(false);
                break;
            };
        }

        public static void ShowMenuAddPeople()
        {
            Console.WriteLine("\nAdd a new person:\n\n");
        }
    }
}
