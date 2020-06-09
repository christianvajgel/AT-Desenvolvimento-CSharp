using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SystemWideOperations
{
    public class Clear
    {
        public static void ClearScreen(bool returnType)
        {
            if (returnType == true) { Console.WriteLine("\nPress any key to return..."); Console.ReadKey(); }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
