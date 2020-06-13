using People;
using System;
using Database;
using static Input.Dates;
using static Input.Strings;
using static Input.Numbers;
using System.Collections.Generic;
using static Database.Repository;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Parsing;
using System.Linq;

namespace Menu
{
    public class Edit
    {
        public static void EditMenu(Repository repository, List<Person> resultList, int id)
        {
            while (true)
            {
                //EditMenu(repository);
                ClearScreen(false);
                var returnedList = ShowMenuEditPeople(repository);
                if (returnedList.Contains("There is no person to edit.")) 
                {
                    Console.WriteLine(returnedList);
                    ClearScreen(true);
                    break;
                }
                Console.WriteLine(ShowMenuEditPeople(repository));
                //Console.Write($"Enter with the ID of the desired person to edit: ");
                var numberID = StringToInt(ReadNumber("id_edit", resultList))[0];
                var firstName = ReadString("new_firstName");
                var surname = ReadString("new_surname");
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
                Console.WriteLine(repository.UpdatePerson(new Person(numberID, firstName, surname, birthday), numberID, peopleFromTextFile));
                ClearScreen(true);
                break;
            };
        }

        public static string ShowMenuEditPeople(Repository repository)
        {
            return repository.ReadPeople(peopleFromTextFile).ToList().Count == 0 ? "\nEdit a person:\n\nThere is no person to edit." :
                                                     $"\nEdit a person:\n\n{GenerateList(repository, peopleFromTextFile)}";
        }
    }
}
