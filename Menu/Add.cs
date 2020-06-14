using People;
using System;
using Database;
using static Input.Dates;
using static Input.Strings;
using System.Collections.Generic;
using static SystemWideOperations.Clear;

namespace Menu
{
    public class Add
    {
        public static bool ok_Add;
        public static void AddMenu(Repository repository, List<Person> resultList, int id)
        {
            while (true)
            {
                ok_Add = false;
                ClearScreen(false);
                ShowMenuAddPeople();
                var firstName = ReadString("firstName");
                var surname = ReadString("surname");
                var birthday = GetDate(resultList);
                var person = new Person(id, firstName, surname, birthday);
                ClearScreen(false);
                var message = repository.AddPerson(person, Repository.peopleFromTextFile);
                if (message.Contains("Person added.")) { ok_Add = true; }
                Console.WriteLine(message);
                ClearScreen(true);
                break;
            };
        }

        public static void ShowMenuAddPeople()
        {
            Console.WriteLine("\nAdd a new person:\n\n");
        }
    }
}
