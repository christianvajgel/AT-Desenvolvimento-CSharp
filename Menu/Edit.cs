using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ClassLibrary_at_csharp;
using static ClassLibrary_at_csharp.Person;
using static ClassLibrary_at_csharp.Parsing;
using static ClassLibrary_at_csharp.Repository;
using static ClassLibrary_at_csharp.Validations;

namespace Menu
{
    public class Edit
    {
        public static void EditMenu(Repository repository)
        {
            ClearScreen(false);
            Console.WriteLine(ShowMenuEditPeople(repository));
            Console.ReadKey();
        }

        public static void ClearScreen(bool returnType)
        {
            if (returnType == true) { Console.WriteLine("\nPress any key to return..."); Console.ReadKey(); }
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static string ShowMenuEditPeople(Repository repository)
        {
            return repository.ReadPeople() == null ? "\nEdit a person:\n\nThere is no person to edit." :
                                                    $"\nEdit a person:\n\n{GenerateList(repository)}";
        }

        public static string GenerateList(Repository repository)
        {
            var list = String.Empty;
            foreach (var person in repository.ReadPeople())
            { list += $"ID: {person.Id}\n" +
                      $"Name: {person.FirstName}\n" +
                      $"Surname: {person.Surname}\n" +
                      $"Birthday: {person.Birthday.ToShortDateString()}\n" +
                      $"\n- - - - - - - - - - - - - - - - - - - - - -\n";
            }
            return list;
        }
    }
}
