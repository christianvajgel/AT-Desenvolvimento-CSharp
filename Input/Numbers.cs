using People;
using System;
using Database;
using SystemWideOperations;
using System.Collections.Generic;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Print;

namespace Input
{
    public class Numbers
    {
        public static string ReadNumber(string option, List<Person> resultList)
        {
            return new Func<string>(() =>
            {
                return option switch
                {
                    "menu" => InputLoopNumber("1", "5", "operation", resultList),
                    "day" => InputLoopNumber("1", "31", "day", resultList),
                    "month" => InputLoopNumber("1", "12", "month", resultList),
                    "year" => InputLoopNumber("1", "9999", "year", resultList),
                    "id" => InputLoopNumber("0", (Repository.peopleFromTextFile.Count - 1).ToString(), "ID number", resultList),
                    "id_edit" => InputLoopNumber("0", (Repository.peopleFromTextFile.Count - 1).ToString(), "ID number of the desired person to edit", resultList),
                    "id_delete" => InputLoopNumber("0", (Repository.peopleFromTextFile.Count - 1).ToString(), "ID number of the desired person to delete", resultList),
                    _ => null,
                };
            })();
        }

        public static string InputLoopNumber(string minimum, string maximum, string type, List<Person> resultList)
        {
            var min = Parsing.StringToInt(minimum)[0];
            var max = Parsing.StringToInt(maximum)[0];
            var ok = false;
            while (true)
            {
                if (type.Equals("ID number") && ok == true) { PrintResultList(resultList); }
                Console.Write("Enter with the " + type + ": ");
                var inputNumber = Console.ReadLine().Trim();
                if (!String.IsNullOrEmpty(inputNumber))
                {
                    var converted = Parsing.StringToInt(inputNumber);
                    if (converted != null && (converted[0] >= min && converted[0] <= max))
                    {
                        return converted[0].ToString();
                    }
                    else
                    {
                        ok = true;
                        Console.WriteLine("\nInvalid number.\n" +
                                          "It must be an interger number between " +
                                          (Parsing.StringToInt(minimum)[0]).ToString() +
                                          " and " + (Parsing.StringToInt(maximum)[0]).ToString() +
                                          ". \nTry again.");
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Empty field.\nTry again.");
                }
                try { ClearScreen(false); } catch (Exception) { }
            }
        }
    }
}
