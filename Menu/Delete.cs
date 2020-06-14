using People;
using System;
using Database;
using System.Linq;
using static Input.Numbers;
using System.Collections.Generic;
using static Database.Repository;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Parsing;

namespace Menu
{
    public class Delete
    {
        public static bool ok_Delete;
        public static void DeleteMenu(Repository repository, List<Person> resultList)
        {
            while (true)
            {
                ok_Delete = false;
                ClearScreen(false);
                resultList = repository.ReadPeople(peopleFromTextFile).ToList();
                var returnedList = ShowMenuDeletePeople(repository, resultList);
                if (returnedList.Contains("There is no person to delete."))
                {
                    Console.WriteLine(returnedList);
                    ClearScreen(true);
                    break;
                }
                Console.WriteLine(returnedList);
                var numberID = StringToInt(ReadNumber("id_delete", resultList))[0];
                ClearScreen(false);
                var message = repository.DeletePerson(numberID,peopleFromTextFile);
                Console.WriteLine(message);
                ClearScreen(true);
                if (!message.Equals("Person does not exists.")) { ok_Delete = true; }
                break;
            }
        }

        // xUnit ShowMenuDeletePeople_Delete()
        public static string ShowMenuDeletePeople(Repository repository, List<Person> peopleFromTextFile)
        {
            return repository.ReadPeople(peopleFromTextFile).ToList().Count == 0 ? "\nDelete a person:\n\nThere is no person to delete." :
                                                    $"\nDelete a person:\n\n{GenerateList(repository,peopleFromTextFile)}";
        }
    }
}
