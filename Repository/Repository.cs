using System;
using People;
using SystemWideOperations;
using System.Collections.Generic;
using static SystemWideOperations.Clear;

namespace Database
{
    public class Repository : IRepository
    {
        //public static List<Person> people = new List<Person>();
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
                //peopleFromTextFile.Add(person); return TextFile.AppendTextToFile(person); }
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
                    //ClearScreen(false);
                    try { ClearScreen(false); } catch (Exception){ }
                    //Console.Clear();
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
                    ReorganizeListObjectsIndex(id);
                    return $"\n\n{result.FirstName} {result.Surname} successfully deleted.";
                }
                else
                {
                    return "Person does not exists.";
                }
            })();
        }

        public static void ReorganizeListObjectsIndex(int id)
        {
            for (var i = peopleFromTextFile.Count - 1; i >= id; i--)
            {
                peopleFromTextFile[i].Id = peopleFromTextFile[i].Id - 1;
            }
        }

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

        public Person SearchPersonById(int id, List<Person> peopleFromTextFile) 
        {
            foreach (var p in peopleFromTextFile) 
            {
                if (p.Id == id) { return p; }
            }
            return null;
        }

        // Return people who is celebrating birthday today
        //public string BirthdayPeopleOfTheDay()
        //{
        //    var resultString = $"\nBirthday people of {DateTime.Today.ToLongDateString()}:\n";
        //    IEnumerable<Person> result = (
        //        from person in peopleFromTextFile
        //        where person.Birthday.Day == DateTime.Today.Day && person.Birthday.Month == DateTime.Today.Month
        //        select person
        //        );
        //    foreach (var person in result)
        //    {
        //        var plural = (DateTime.Today.Year - person.Birthday.Year != 1) ? "years" : "year";
        //        resultString += $"\n - {person.FirstName} {person.Surname} :: {DateTime.Today.Year - person.Birthday.Year} {plural} old\n";
        //    }
        //    return !result.Any() ? $"\n{resultString}\n - There is no person celebrating birthday today." : resultString;
        //}

        //public int DateCountdown(string id)
        //{
        //    return new Func<int>(() => { return CalculateDays(SearchPerson(Parsing.StringToInt(id)[0])); })();
        //}

        public static Person SearchPerson(int id, List<Person> peopleFromTextFile)
        {
            //var PersonObject = new Person();
            foreach (var match in peopleFromTextFile)
            {
                if (match.Id == id) { return peopleFromTextFile[match.Id]; }
            }
            return null;

            //var PersonObject = new Person();
            //foreach (var match in people)
            //{
            //    if (match.Id == id) { PersonObject = people[match.Id]; }
            //}
            //return PersonObject;
        }

        //public int CalculateDays(Person person)
        //{
        //    var nextBirthday = person.Birthday.AddYears(DateTime.Today.Year - person.Birthday.Year);
        //    if (nextBirthday < DateTime.Today) { nextBirthday = nextBirthday.AddYears(1); }
        //    return (nextBirthday - DateTime.Today).Days;
        //}

        public string PersonFullName(string id)
        {
            var person = SearchPerson(Parsing.StringToInt(id)[0],peopleFromTextFile);
            return $"{person.FirstName} {person.Surname}";
        }

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
