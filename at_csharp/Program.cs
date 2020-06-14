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

        public static string UNDERLINE = "\x1B[4m";
        public static string RESET = "\x1B[0m";
        
        public static List<Person> resultList = new List<Person>();
        public static Repository repository = new Repository();
        public static int id = TextFile.CheckCurrentId();

        static void Main(string[] args)
        {
            var handle = GetStdHandle(STD_OUTPUT_HANDLE);
            uint mode;
            GetConsoleMode(handle, out mode);
            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            SetConsoleMode(handle, mode);

            TextFile.ReadTextFile();

            while (true)
            {
                Console.WriteLine(BirthdayPeopleOfTheDay(Repository.peopleFromTextFile));
                MainMenu();
                var operation = ReadNumber("menu", resultList);

                if (operation.Equals("5")) { TextFile.CloseTextFile(); break; }
                else
                {
                    switch (operation)
                    {
                        case "1":
                            SearchMenu(repository, resultList, UNDERLINE, RESET); 
                            break;
                        case "2":
                            AddMenu(repository, resultList, id); 
                            if (ok_Add == true) { id++; } 
                            break;
                        case "3":
                            EditMenu(repository, resultList, id);
                            break;
                        case "4":
                            DeleteMenu(repository, resultList);
                            if (ok_Delete == true) { id--; }
                            break;
                    }
                }
            }
        }
    }
}
