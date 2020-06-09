using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Database;
using static Database.Repository;
using People;
using SystemWideOperations;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Print;
using static SystemWideOperations.Parsing;
using static Input.Dates;
using static Input.Strings;
using static Input.Numbers;

namespace Menu
{
    public class Delete
    {
        public static Boolean ok_Delete;
        public static void DeleteMenu(Repository repository, List<Person> resultList) 
        {
            while (true)
            {
                ok_Delete = false;
                ClearScreen(false);
                Console.WriteLine(ShowMenuDeletePeople(repository));
                //Console.Write($"Enter with the ID of the desired person to edit: ");

                var numberID = StringToInt(ReadNumber("id_delete", resultList))[0];

                var message = repository.DeletePerson(numberID);
                Console.WriteLine(message);
                ClearScreen(true);
                if (!message.Equals("Person does not exists.")) { ok_Delete = true; }
                break;
            }
        }

        public static string ShowMenuDeletePeople(Repository repository)
        {
            return repository.ReadPeople() == null ? "\nDelete a person:\n\nThere is no person to delete." :
                                                    $"\nDelete a person:\n\n{GenerateList(repository)}";
        }
    }
}
