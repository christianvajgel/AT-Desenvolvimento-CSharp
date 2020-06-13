using System;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Validations;

namespace Input
{
    public class Strings
    {
        public static string ReadString(string option)
        {
            return new Func<string>(() =>
            {
                return option switch
                {
                    "firstName" => InputLoopString("first name"),
                    "surname" => InputLoopString("surname"),
                    "new_firstName" => InputLoopString("new firstname"),
                    "new_surname" => InputLoopString("new surname"),
                    _ => null,
                };
            })();
        }

        public static string InputLoopString(string custom)
        {
            while (true)
            {
                Console.Write("Enter with the " + custom + ": ");
                var inputString = Console.ReadLine().Trim();
                if (!String.IsNullOrEmpty(inputString))
                {
                    if (StringValidation(inputString)[0].Equals("valid") &&
                       !StringValidation(inputString)[1].Equals("valid"))
                    {
                        return inputString;
                    }
                    else
                    {
                        Console.WriteLine("Invalid data.\nTry again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Empty field.\n" +
                                      "Try again.");
                }
                try { ClearScreen(false); } catch (Exception) { }
            }
        }
    }
}
