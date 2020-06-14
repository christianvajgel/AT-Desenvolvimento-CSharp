using People;
using System;
using Database;
using System.Linq;
using static Input.Strings;
using static Input.Numbers;
using static Birthday.Calculate;
using System.Collections.Generic;
using static Database.Repository;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Print;

namespace Menu
{
    public class Search
    {
        public static void SearchMenu(Repository repository, List<Person> resultList, string UNDERLINE, string RESET)
        {
            while (true)
            {
                ClearScreen(false);
                ShowMenuSearchPeople();
                var firstName = ReadString("firstName");
                var surname = ReadString("surname");
                resultList = repository.SearchPeople(firstName, surname, peopleFromTextFile);
                Loading();
                if (resultList.Any())
                {
                    ClearScreen(false);
                    Console.WriteLine($"\n\nSearch Results " +
                                          $"for the contexts {UNDERLINE}{firstName.ToUpper()}{RESET} " +
                                          $"and {UNDERLINE}{surname.ToUpper()}{RESET}:\n");
                    PrintResultList(resultList);
                    Console.WriteLine($"Choose the ID of the desired " +
                                      $"person to check the countdown.\n");
                    var numberID = ReadNumber("id", resultList);
                    var countdown = DateCountdown(numberID, peopleFromTextFile);
                    var verb = "are";
                    var dayWord = "days";
                    if (countdown == 1) { verb = "is"; dayWord = "day"; }
                    ClearScreen(false);
                    if (countdown == 0) { Console.WriteLine($"\n\nToday is {repository.PersonFullName(numberID, peopleFromTextFile)}'s birthday!"); }
                    else { Console.WriteLine($"\n\nThere {verb} {countdown} {dayWord} before {repository.PersonFullName(numberID, peopleFromTextFile)}'s birthday!"); }
                }
                else
                {
                    ClearScreen(false);
                    Console.WriteLine($"\nNo results were found with these " +
                                      $"search contexts: '{UNDERLINE}{firstName}{RESET}' " +
                                      $"and '{UNDERLINE}{surname}{RESET}'.\nTry again.");
                }
                ClearScreen(true);
                break;
            }
        }

        public static void ShowMenuSearchPeople()
        {
            Console.WriteLine("\nSearch for a person:\n\n");
        }
    }
}
