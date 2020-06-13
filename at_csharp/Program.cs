using People;
using System;
using Database;
using static Menu.Add;
using static Menu.Main;
using static Menu.Edit;
using static Menu.Search;
using static Menu.Delete;
using static Input.Numbers;
using static Birthday.Today;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace at_csharp
{
    class Program
    {
        const int STD_OUTPUT_HANDLE = -11;
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        public static List<Person> resultList = new List<Person>();
        public static Repository repository = new Repository();
        public static int id = TextFile.CheckCurrentId();

        public static string UNDERLINE = "\x1B[4m";
        public static string RESET = "\x1B[0m";

        static void Main(string[] args)
        {
            var handle = GetStdHandle(STD_OUTPUT_HANDLE);
            uint mode;
            GetConsoleMode(handle, out mode);
            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            SetConsoleMode(handle, mode);

            TextFile.ReadTextFile();
            //var id = TextFile.CheckCurrentId();

            while (true)
            {
                Console.WriteLine(BirthdayPeopleOfTheDay());
                //ShowMenu();
                MainMenu();
                var operation = ReadNumber("menu", resultList);
                if (operation.Equals("5"))
                {
                    TextFile.CloseTextFile();
                    break;
                }
                else
                {
                    switch (operation)
                    {
                        case "1":
                            SearchMenu(repository, resultList, UNDERLINE, RESET);

                            //while (true)
                            //{
                            //    ClearScreen(false);
                            //    ShowMenuSearchPeople();
                            //    var firstName = ReadString("firstName");
                            //    var surname = ReadString("surname");
                            //    resultList = repository.SearchPeople(firstName, surname);
                            //    //Loading();
                            //    if (resultList.Any())
                            //    {
                            //        ClearScreen(false);
                            //        Console.WriteLine($"\n\nSearch Results " +
                            //                              $"for the contexts {UNDERLINE}{firstName.ToUpper()}{RESET} " +
                            //                              $"and {UNDERLINE}{surname.ToUpper()}{RESET}:\n");
                            //        PrintResultList(resultList);
                            //        Console.WriteLine($"Choose the ID of the desired " +
                            //                          $"person to check the countdown.\n");
                            //        var numberID = ReadNumber("id", resultList);
                            //        var countdown = repository.DateCountdown(numberID);
                            //        var verb = "are";
                            //        var dayWord = "days";
                            //        if (countdown == 1) { verb = "is"; dayWord = "day"; }
                            //        ClearScreen(false);
                            //        Console.WriteLine($"There {verb} {countdown} {dayWord} " +
                            //                          $"before {repository.PersonFullName(numberID)}'s birthday.");
                            //    }
                            //    else
                            //    {
                            //        ClearScreen(false);
                            //        Console.WriteLine($"\nNo results were found with these " +
                            //                          $"search contexts: '{UNDERLINE}{firstName}{RESET}' " +
                            //                          $"and '{UNDERLINE}{surname}{RESET}'.\nTry again.");
                            //    }
                            //    ClearScreen(true);
                            //    break;
                            //}
                            break;
                        case "2":
                            AddMenu(repository, resultList, id);
                            if (ok_Add == true) { id++; }
                            //while (true)
                            //{
                            //    ClearScreen(false);
                            //    ShowMenuAddPeople();

                            //    var firstName = ReadString("firstName");
                            //    var surname = ReadString("surname");
                            //    //var birthday = GetDate(resultList);
                            //    var birthday = new Func<DateTime>(() =>
                            //    {
                            //        var completeDate = "";
                            //        var finalDate = new DateTime();
                            //        do
                            //        {
                            //            var day = ReadNumber("day", resultList);
                            //            var month = ReadNumber("month", resultList);
                            //            var year = ReadNumber("year", resultList);
                            //            completeDate = year + "/" + month + "/" + day;
                            //            if (DateValidation(completeDate) == default)
                            //            {
                            //                Console.WriteLine("Invalid date.\nTry again.");
                            //                ClearScreen(false);
                            //            }
                            //            else
                            //            {
                            //                finalDate = ConvertToDateTimeObject(day, month, year)[0];
                            //            }
                            //        } while (DateValidation(completeDate) == default);
                            //        return finalDate;
                            //    })();
                            //    //var person = new Person(Guid.NewGuid(), firstName, surname, birthday);
                            //    var person = new Person(id, firstName, surname, birthday);
                            //    var message = repository.AddPerson(person);

                            //    if (message.Equals("Person added.")) { id++; }
                            //    Console.WriteLine(message);
                            //    ClearScreen(false);
                            //    break;
                            //};
                            break;
                        case "3":
                            EditMenu(repository, resultList, id);

                            //while (true)
                            //{
                            //    //EditMenu(repository);

                            //    ClearScreen(false);
                            //    Console.WriteLine(ShowMenuEditPeople(repository));
                            //    //Console.Write($"Enter with the ID of the desired person to edit: ");

                            //    var numberID = StringToInt(ReadNumber("id_edit", resultList))[0];

                            //    var firstName = ReadString("new_firstName");
                            //    var surname = ReadString("new_surname");

                            //    var birthday = new Func<DateTime>(() =>
                            //    {
                            //        var completeDate = "";
                            //        var finalDate = new DateTime();
                            //        do
                            //        {
                            //            var day = ReadNumber("day", resultList);
                            //            var month = ReadNumber("month", resultList);
                            //            var year = ReadNumber("year", resultList);
                            //            completeDate = year + "/" + month + "/" + day;
                            //            if (DateValidation(completeDate) == default)
                            //            {
                            //                Console.WriteLine("Invalid date.\nTry again.");
                            //                ClearScreen(false);
                            //            }
                            //            else
                            //            {
                            //                finalDate = ConvertToDateTimeObject(day, month, year)[0];
                            //            }
                            //        } while (DateValidation(completeDate) == default);
                            //        return finalDate;
                            //    })();
                            //    Console.WriteLine(repository.UpdatePerson(new Person(numberID, firstName, surname, birthday), numberID));
                            //    ClearScreen(true);
                            //    break;
                            //};
                            break;
                        case "4":
                            DeleteMenu(repository, resultList);
                            if (ok_Delete == true) { id--; }
                            //while (true)
                            //{
                            //    ClearScreen(false);
                            //    Console.WriteLine(ShowMenuDeletePeople(repository));
                            //    //Console.Write($"Enter with the ID of the desired person to edit: ");

                            //    var numberID = StringToInt(ReadNumber("id_delete", resultList))[0];

                            //    Console.WriteLine(repository.DeletePerson(numberID));
                            //    ClearScreen(true);
                            //    break;
                            //}
                            break;
                    }
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n*** C# Birthday Manager ***\n\n  " +
                                        "Select an option:\n    " +
                                        "1- Search people\n    " +
                                        "2- Add people\n    " +
                                        "3- Edit people\n    " +
                                        "4- Delete people\n    " +
                                        "5- EXIT\n\n");
        }

        //public static void ShowMenuAddPeople()
        //{
        //    Console.WriteLine("\nAdd a new person:\n\n");
        //}

        //public static void ShowMenuSearchPeople()
        //{
        //    Console.WriteLine("\nSearch for a person:\n\n");
        //}

        //public static string ShowMenuEditPeople(Repository repository)
        //{
        //    return repository.ReadPeople() == null ? "\nEdit a person:\n\nThere is no person to edit." :
        //                                             $"\nEdit a person:\n\n{GenerateList(repository)}";
        //}

        //public static string ShowMenuDeletePeople(Repository repository)
        //{
        //    return repository.ReadPeople() == null ? "\nDelete a person:\n\nThere is no person to delete." :
        //                                            $"\nEdit a person:\n\n{GenerateList(repository)}";
        //}

        //public static string GenerateList(Repository repository)
        //{
        //    var list = String.Empty;
        //    foreach (var person in repository.ReadPeople())
        //    {
        //        list += $"\nID: {person.Id}\n" +
        //                $"Name: {person.FirstName}\n" +
        //                $"Surname: {person.Surname}\n" +
        //                $"Birthday: {person.Birthday.ToShortDateString()}\n" +
        //                $"\n- - - - - - - - - - - - - - - - - - - - - -\n";
        //    }
        //    return list;
        //}

        //public static string ReadNumber(string option, List<Person> resultList)
        //{
        //    return new Func<string>(() =>
        //    {
        //        return option switch
        //        {
        //            "menu" => InputLoopNumber("1", "5", "operation", resultList),
        //            "day" => InputLoopNumber("1", "31", "day", resultList),
        //            "month" => InputLoopNumber("1", "12", "month", resultList),
        //            "year" => InputLoopNumber("1", "9999", "year", resultList),
        //            "id" => InputLoopNumber("0", (Repository.peopleFromTextFile.Count() - 1).ToString(), "ID number", resultList),
        //            "id_edit" => InputLoopNumber("0", (Repository.peopleFromTextFile.Count() - 1).ToString(), "ID number of the desired person to edit", resultList),
        //            "id_delete" => InputLoopNumber("0", (Repository.peopleFromTextFile.Count() - 1).ToString(), "ID number of the desired person to delete", resultList),
        //            _ => null,
        //        };
        //    })();
        //}

        //public static string ReadString(string option)
        //{
        //    return new Func<string>(() =>
        //    {
        //        return option switch
        //        {
        //            "firstName" => InputLoopString("first name"),
        //            "surname" => InputLoopString("surname"),
        //            "new_firstName" => InputLoopString("new first name"),
        //            "new_surname" => InputLoopString("new surname"),
        //            _ => null,
        //        };
        //    })();
        //}

        //public static string InputLoopNumber(string minimum, string maximum, string type, List<Person> resultList)
        //{
        //    var min = Parsing.StringToInt(minimum)[0];
        //    var max = Parsing.StringToInt(maximum)[0];
        //    var ok = false;
        //    while (true)
        //    {
        //        if (type.Equals("ID number") && ok == true) { PrintResultList(resultList); }
        //        Console.Write("Enter with the " + type + ": ");
        //        var inputNumber = Console.ReadLine().Trim();
        //        if (!String.IsNullOrEmpty(inputNumber))
        //        {
        //            var converted = Parsing.StringToInt(inputNumber);
        //            if (converted != null && (converted[0] >= min && converted[0] <= max))
        //            {
        //                return converted[0].ToString();
        //            }
        //            else
        //            {
        //                ok = true;
        //                Console.WriteLine("\nInvalid number.\n" +
        //                                  "It must be an interger number between " +
        //                                  (Parsing.StringToInt(minimum)[0]).ToString() +
        //                                  " and " + (Parsing.StringToInt(maximum)[0]).ToString() +
        //                                  ". \nTry again.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nError: Empty field.\nTry again.");
        //        }
        //        ClearScreen(false);
        //    }
        //}

        //public static void ClearScreen(bool returnType)
        //{
        //    if (returnType == true) { Console.WriteLine("\nPress any key to return..."); Console.ReadKey(); }
        //    Thread.Sleep(1000);
        //    Console.Clear();
        //}

        //public static string InputLoopString(string custom)
        //{
        //    while (true)
        //    {
        //        Console.Write("Enter with the " + custom + ": ");
        //        var inputString = Console.ReadLine().Trim();
        //        if (!String.IsNullOrEmpty(inputString))
        //        {
        //            if (StringValidation(inputString)[0].Equals("valid") &&
        //               !StringValidation(inputString)[1].Equals("valid"))
        //            {
        //                return inputString;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid data.\nTry again.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error: Empty field.\n" +
        //                              "Try again.");
        //        }
        //        ClearScreen(false);
        //    }
        //}

        //public static void PrintResultList(List<Person> resultList)
        //{
        //    foreach (var result in resultList)
        //    {
        //        Console.WriteLine($"ID: {result.Id}\n" +
        //                          $"Name: {result.FirstName}\n" +
        //                          $"Surname: {result.Surname}\n" +
        //                          $"Birthday: {result.Birthday.ToShortDateString()}\n" +
        //                          $"\n- - - - - - - - - - - - - - - - - - - - - -\n");
        //    }
        //}

        //public static void Loading()
        //{
        //    Console.WriteLine("\n\nSearching");
        //    for (var i = 0; i <= 30; i++)
        //    {
        //        Console.Write("-");
        //        Thread.Sleep(250);
        //        if (i == 30) { Console.WriteLine("\n"); }
        //    }
        //}
    }
}
