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
                try { ClearScreen(false); } catch (Exception) { }
                var returnedList = ShowMenuEditPeople(repository);
                if (returnedList.Contains("There is no person to edit.")) 
                {
                    Console.WriteLine(returnedList);
                    try { ClearScreen(true); } catch (Exception) { }
                    break;
                }
                resultList = repository.ReadPeople(peopleFromTextFile).ToList();
                Console.WriteLine(ShowMenuEditPeople(repository));
                //Console.Write($"Enter with the ID of the desired person to edit: ");
                var numberID = StringToInt(ReadNumber("id_edit", resultList))[0];
                try { ClearScreen(false); } catch (Exception) { }
                Console.WriteLine(ShowPersonToEdit(numberID,repository,resultList));
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
                try { ClearScreen(true); } catch (Exception) { }
                break;
            };
        }

        public static string ShowMenuEditPeople(Repository repository)
        {
            return repository.ReadPeople(peopleFromTextFile).ToList().Count == 0 ? "\nEdit a person:\n\nThere is no person to edit." :
                                                                                  $"\nEdit a person:\n\n{GenerateList(repository, peopleFromTextFile)}";
        }

        public static string ShowPersonToEdit(int id, Repository repository, List<Person> resultList) 
        {
            var person = repository.SearchPersonById(id, resultList);
            return $"\n\nEdit {person.FirstName}:\n    " +
                   $"\n    Name: {person.FirstName}" +
                   $"\n    Surname: {person.Surname}" +
                   $"\n    Birthday: {person.Birthday.ToShortDateString()}" +
                   $"\n\n- - - - - - - - - - - - - - - - - - - - - -\n";
        }
    }
}
