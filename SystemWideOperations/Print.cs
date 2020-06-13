using System;
using People;
using System.Threading;
using System.Collections.Generic;

namespace SystemWideOperations
{
    public class Print
    {
        public static void PrintResultList(List<Person> resultList)
        {
            foreach (var result in resultList)
            {
                Console.WriteLine($"ID: {result.Id}\n" +
                                  $"Name: {result.FirstName}\n" +
                                  $"Surname: {result.Surname}\n" +
                                  $"Birthday: {result.Birthday.ToShortDateString()}\n" +
                                  $"\n- - - - - - - - - - - - - - - - - - - - - -\n");
            }
        }

        public static void Loading()
        {
            Console.WriteLine("\n\nSearching");
            for (var i = 0; i <= 30; i++)
            {
                Console.Write("-");
                Thread.Sleep(250);
                if (i == 30) { Console.WriteLine("\n"); }
            }
        }
    }
}
