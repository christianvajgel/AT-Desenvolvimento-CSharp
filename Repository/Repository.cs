using System;
using People;
using SystemWideOperations;
using System.Collections.Generic;
using static SystemWideOperations.Clear;

namespace Database
{
    public class Repository : IRepository
    {
        public static List<Person> peopleFromTextFile = new List<Person>();

        // CREATE -> xUnit [Fact] Create_AddPersonToList()
        public string AddPerson(Person person, List<Person> peopleFromTextFile)
        {
            return new Func<String>(() =>
            {
                if (CheckContactExistence(person, peopleFromTextFile)) { return "Person already exists."; }
                else
                {
                    peopleFromTextFile.Add(person); return $"\nPerson added.\n\nDATA:\n\n    " +
                                                           $"- Name: {person.FirstName} {person.Surname}\n    " +
                                                           $"- Birthday: {person.Birthday.ToShortDateString()}";
                }
            })();
        }

        // READ -> xUnit [Fact] Read_ReadPeople() 
        public IEnumerable<Person> ReadPeople(List<Person> peopleFromTextFile)
        {
            return peopleFromTextFile;
        }

        // UPDATE -> xUnit [Fact] Update_UpdatePerson() 
        public string UpdatePerson(Person person, int id, List<Person> peopleFromTextFile)
        {
            return new Func<String>(() =>
            {
                var result = SearchPerson(id, peopleFromTextFile);
                if (CheckContactExistence(result, peopleFromTextFile))
                {
                    peopleFromTextFile[result.Id] = person;
                    ClearScreen(false);
                    return $"\nContact successfully updated." +
                           $"\n\n\nOld data:" +
                           $"\n\n  - Name: {result.FirstName} {result.Surname}\n  - Birthday: {result.Birthday.ToShortDateString()}" +
                           $"\n\n\nNew data:" +
                           $"\n\n  - Name: {person.FirstName} {person.Surname}\n  - Birthday: {person.Birthday.ToShortDateString()}\n";
                }
                else
                {
                    return "Person doesn't exists.";
                }
            })();
        }

        // DELETE -> xUnit [Fact] Delete_DeletePerson() 
        public string DeletePerson(int id, List<Person> peopleFromTextFile)
        {
            return new Func<String>(() =>
            {
                var result = SearchPerson(id, peopleFromTextFile);
                if (result != null && result.Id == id)
                {
                    peopleFromTextFile.Remove(result);
                    ReorganizeListObjectsIndex(id, peopleFromTextFile);
                    return $"\n\n{result.FirstName} {result.Surname} successfully deleted.";
                }
                else
                {
                    return "Person does not exists.";
                }
            })();
        }

        // xUnit ReorganizeListObjectsIndex_Repository() 
        public static void ReorganizeListObjectsIndex(int id, List<Person> peopleFromTextFile)
        {
            for (var i = peopleFromTextFile.Count - 1; i >= id; i--)
            {
                peopleFromTextFile[i].Id = peopleFromTextFile[i].Id - 1;
            }
        }

        // xUnit SearchPeople_SingleResult_Repository()
        //       SearchPeople_MultipleResults_Repository() 
        public List<Person> SearchPeople(string termFirstName, string termSurname, List<Person> peopleFromTextFile)
        {
            var result = new List<Person>();
            foreach (var match in peopleFromTextFile)
            {
                if (match.FirstName.Contains(termFirstName, StringComparison.InvariantCultureIgnoreCase) ||
                    match.Surname.Contains(termSurname, StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(match);
                }
            }
            return result;
        }

        // xUnit SearchPerson_Repository()
        public static Person SearchPerson(int id, List<Person> peopleFromTextFile)
        {
            foreach (var match in peopleFromTextFile)
            {
                if (match.Id == id) { return peopleFromTextFile[match.Id]; }
            }
            return null;
        }

        // xUnit PersonFullName_Repository()
        public string PersonFullName(string id, List<Person> peopleFromTextFile)
        {
            var person = SearchPerson(Parsing.StringToInt(id)[0],peopleFromTextFile);
            return $"{person.FirstName} {person.Surname}";
        }

        // xUnit CheckContactExistence_Repository()
        public static bool CheckContactExistence(Person person, List<Person> peopleFromTextFile)
        {
            return new Func<bool>(() =>
            {
                foreach (var match in peopleFromTextFile)
                {
                    if (match.FirstName.Equals(person.FirstName)
                        && match.Surname.Equals(person.Surname)
                        && match.Birthday.Equals(person.Birthday)
                        && match == person)
                    {
                        return true;
                    }
                }
                return false;
            })();
        }

        // xUnit GenerateList_Repository()
        public static string GenerateList(Repository repository, List<Person> peopleFromTextFile)
        {
            var list = String.Empty;
            foreach (var person in repository.ReadPeople(peopleFromTextFile))
            {
                list += $"\nID: {person.Id}\n" +
                        $"Name: {person.FirstName}\n" +
                        $"Surname: {person.Surname}\n" +
                        $"Birthday: {person.Birthday.ToShortDateString()}\n" +
                        $"\n- - - - - - - - - - - - - - - - - - - - - -\n";
            }
            return list;
        }
    }
}
