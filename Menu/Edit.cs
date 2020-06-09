﻿using System;
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
    public class Edit
    {
        public static void EditMenu(Repository repository, List<Person> resultList, int id)
        {
            while (true)
            {
                //EditMenu(repository);

                ClearScreen(false);
                Console.WriteLine(ShowMenuEditPeople(repository));
                //Console.Write($"Enter with the ID of the desired person to edit: ");

                var numberID = StringToInt(ReadNumber("id_edit", resultList))[0];

                var firstName = ReadString("new_firstName");
                var surname = ReadString("new_surname");
                var birthday = GetDate(resultList);

                //var birthday = new Func<DateTime>(() =>
                //{
                //    var completeDate = "";
                //    var finalDate = new DateTime();
                //    do
                //    {
                //        var day = ReadNumber("day", resultList);
                //        var month = ReadNumber("month", resultList);
                //        var year = ReadNumber("year", resultList);
                //        completeDate = year + "/" + month + "/" + day;
                //        if (DateValidation(completeDate) == default)
                //        {
                //            Console.WriteLine("Invalid date.\nTry again.");
                //            ClearScreen(false);
                //        }
                //        else
                //        {
                //            finalDate = ConvertToDateTimeObject(day, month, year)[0];
                //        }
                //    } while (DateValidation(completeDate) == default);
                //    return finalDate;
                //})();
                Console.WriteLine(repository.UpdatePerson(new Person(numberID, firstName, surname, birthday), numberID));
                ClearScreen(true);
                break;
            };
        }

        public static string ShowMenuEditPeople(Repository repository)
        {
            return repository.ReadPeople() == null ? "\nEdit a person:\n\nThere is no person to edit." :
                                                     $"\nEdit a person:\n\n{GenerateList(repository)}";
        }
    }
}
