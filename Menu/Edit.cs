using People;
using System;
using Database;
using System.Linq;
using static Input.Dates;
using static Input.Strings;
using static Input.Numbers;
using System.Collections.Generic;
using static Database.Repository;
using static SystemWideOperations.Clear;
using static SystemWideOperations.Parsing;

namespace Menu
{
    public class Edit
    {
        public static void EditMenu(Repository repository, List<Person> resultList, int id)
        {
            while (true)
            {
                ClearScreen(false);
                resultList = repository.ReadPeople(peopleFromTextFile).ToList();
                var returnedList = ShowMenuEditPeople(repository, resultList);
                if (returnedList.Contains("There is no person to edit.")) 
                {
                    Console.WriteLine(returnedList);
                    ClearScreen(true);
                    break;
                }
                Console.WriteLine(ShowMenuEditPeople(repository, resultList));
                var numberID = StringToInt(ReadNumber("id_edit", resultList))[0];
                ClearScreen(false);
                Console.WriteLine(ShowPersonToEdit(numberID,repository,resultList));
                var firstName = ReadString("new_firstName");
                var surname = ReadString("new_surname");
                var birthday = GetDate(resultList);
                Console.WriteLine(repository.UpdatePerson(new Person(numberID, firstName, surname, birthday), numberID, peopleFromTextFile));
                ClearScreen(true);
                break;
            };
        }

        // xUnit ShowMenuEditPeople_Edit() 
        public static string ShowMenuEditPeople(Repository repository, List<Person> peopleFromTextFile)
        {
            return repository.ReadPeople(peopleFromTextFile).ToList().Count == 0 ? "\nEdit a person:\n\nThere is no person to edit." :
                                                                                  $"\nEdit a person:\n\n{GenerateList(repository, peopleFromTextFile)}";
        }

        // xUnit ShowPersonToEdit_Edit()
        public static string ShowPersonToEdit(int id, Repository repository, List<Person> resultList) 
        {
            var person = SearchPerson(id, resultList);
            return $"\n\nEdit {person.FirstName}:\n    " +
                   $"\n    Name: {person.FirstName}" +
                   $"\n    Surname: {person.Surname}" +
                   $"\n    Birthday: {person.Birthday.ToShortDateString()}" +
                   $"\n\n- - - - - - - - - - - - - - - - - - - - - -\n";
        }
    }
}
