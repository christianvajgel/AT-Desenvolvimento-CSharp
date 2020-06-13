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
                var returnedList = ShowMenuDeletePeople(repository);
                if (returnedList.Contains("There is no person to delete."))
                {
                    Console.WriteLine(returnedList);
                    ClearScreen(true);
                    break;
                }
                Console.WriteLine(returnedList);
                //Console.Write($"Enter with the ID of the desired person to edit: ");
                var numberID = StringToInt(ReadNumber("id_delete", resultList))[0];
                var message = repository.DeletePerson(numberID,peopleFromTextFile);
                Console.WriteLine(message);
                ClearScreen(true);
                if (!message.Equals("Person does not exists.")) { ok_Delete = true; }
                break;
            }
        }

        public static string ShowMenuDeletePeople(Repository repository)
        {
            return repository.ReadPeople(peopleFromTextFile).ToList().Count == 0 ? "\nDelete a person:\n\nThere is no person to delete." :
                                                    $"\nDelete a person:\n\n{GenerateList(repository,peopleFromTextFile)}";
        }
    }
}
