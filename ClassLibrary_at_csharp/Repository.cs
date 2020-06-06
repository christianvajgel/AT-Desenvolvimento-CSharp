using System;
using System.Linq;
using System.Collections.Generic;

namespace ClassLibrary_at_csharp
{
    public class Repository : IRepository
    {
        public static List<Person> people = new List<Person>();
        public static List<Person> peopleFromTextFile = new List<Person>();

        // CREATE
        public string AddPerson(Person person)
        {
            return new Func<String>(() =>
            {
                if (CheckContactExistence(person)) { return "Person already exists."; }
                else { 
                    peopleFromTextFile.Add(person); return "Person added."; }
                    //peopleFromTextFile.Add(person); return TextFile.AppendTextToFile(person); }
            })();
        }

        // READ
        public IEnumerable<Person> ReadPeople()
        {
            return peopleFromTextFile;
        }

        // UPDATE - create menu - show list 
        public string UpdatePerson(Person person, int id)
        {
            return new Func<String>(() =>
            {
                var result = SearchPerson(id);
                if (CheckContactExistence(result))
                {
                    peopleFromTextFile[result.Id] = person;
                    return $"\nContact updated successfully.\nOld data:\n {result.FirstName} " +
                           $"{result.Surname} | Birthday: {result.Birthday.ToShortDateString()}" +
                           $"\nNew data:\n {person.FirstName} {person.Surname} " +
                           $"\nBirthday: {person.Birthday.ToShortDateString()}";
                }
                else
                {
                    return "Person doesn't exists.";
                }
            })();
        }

        // DELETE - create menu - change everyone ID after delete process
        public string DeletePerson(int id)
        {
            return new Func<String>(() =>
            {
                var result = SearchPerson(id);
                if (result != null && result.Id == id)
                {
                    peopleFromTextFile.Remove(result);
                    ReorganizeListObjectsIndex(id);
                    return $"{result.FirstName} {result.Surname} successfully deleted.";
                }
                else
                {
                    return "Person does not exists.";
                }
            })();
        }

        public static void ReorganizeListObjectsIndex(int id) 
        {
            //Console.WriteLine("\n* * * * * * * Original List * * * * * * *\n");

            //foreach (var p in TextFile.peopleFromTextFile)
            //{
            //    Console.WriteLine($"{p.Id} {p.FirstName} {p.Surname} {p.Birthday}\n");
            //}

            //Console.WriteLine("\n* * * * * * Modification * * * * * * * *\n");

            for (var i = peopleFromTextFile.Count - 1; i >= id; i--) 
            {
                peopleFromTextFile[i].Id = peopleFromTextFile[i].Id - 1;
            }

            //Console.WriteLine("\n* * * * * * * New list * * * * * * *\n");

            //foreach(var p in TextFile.peopleFromTextFile) 
            //{
            //    Console.WriteLine($"{p.Id} {p.FirstName} {p.Surname} {p.Birthday}\n");
            //}

            //Console.WriteLine("\n* * * * * * * * * * * * * * *\n");

            //Console.ReadKey();
        }

        // Search for keywords
        public IEnumerable<Person> SearchPeople(string termFirstName, string termSurname)
        {
            return peopleFromTextFile.Where(person =>
                                            person.FirstName.Contains(termFirstName, StringComparison.InvariantCultureIgnoreCase) ||
                                            person.Surname.Contains(termSurname, StringComparison.InvariantCultureIgnoreCase));
        }

        // Return people who is celebrating birthday today
        public string BirthdayPeopleOfTheDay()
        {
            var resultString = $"\nBirthday people of {DateTime.Today.ToLongDateString()}:\n";
            IEnumerable<Person> result = (
                from person in peopleFromTextFile
                where person.Birthday.Day == DateTime.Today.Day && person.Birthday.Month == DateTime.Today.Month
                select person
                );
            foreach (var person in result) 
            {
                var plural = (DateTime.Today.Year - person.Birthday.Year != 1) ? "years" : "year";
                resultString += $"\n - {person.FirstName} {person.Surname} :: {DateTime.Today.Year - person.Birthday.Year} {plural} old\n";
            }
            return !result.Any() ? "There is no person celebrating birthday today" : resultString;
        }

        //public static int GetPeopleAge(DateTime date) 
        //{
        //    return new Func<int>(() => {

        //        return date.Year - DateTime.Today.Year;
        //       })();

            
        //}

        public int DateCountdown(string id)
        {
            return new Func<int>(() => { return CalculateDays(SearchPerson(Parsing.StringToInt(id)[0])); })();
        }

        public static Person SearchPerson(int id)
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

        public int CalculateDays(Person person)
        {
            var nextBirthday = person.Birthday.AddYears(DateTime.Today.Year - person.Birthday.Year);
            if (nextBirthday < DateTime.Today) { nextBirthday = nextBirthday.AddYears(1); }
            return (nextBirthday - DateTime.Today).Days;
        }

        public string PersonFullName(string id)
        {
            var person = SearchPerson(Parsing.StringToInt(id)[0]);
            return $"{person.FirstName} {person.Surname}";
        }

        public static Boolean CheckContactExistence(Person person)
        {
            return new Func<Boolean>(() =>
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

        //public static List<Person> people = new List<Person>();

        //public static string AddPerson(Person person)
        //{
        //    return new Func<String>(() =>
        //    {
        //        if (CheckContactExistence(person)) { return "Person already exists."; }
        //        else { people.Add(person); return "Person added."; }
        //    })();
        //}

        //public static IEnumerable<Person> SearchPeople(string termFirstName, string termSurname)
        //{
        //    return people.Where(person =>
        //        person.FirstName.Contains(termFirstName, StringComparison.InvariantCultureIgnoreCase) ||
        //        person.SurnameName.Contains(termSurname, StringComparison.InvariantCultureIgnoreCase));
        //}

        //public static int DateCountdown(string id)
        //{
        //    return new Func<int>(() => { return CalculateDays(SearchPerson(Parsing.StringToInt(id)[0])); })();
        //}

        //public static Person SearchPerson(int id)
        //{
        //    var PersonObject = new Person();
        //    foreach (var match in people)
        //    {
        //        if (match.Id == id) { PersonObject = people[match.Id]; }
        //    }
        //    return PersonObject;
        //}

        //public static int CalculateDays(Person person)
        //{
        //    var nextBirthday = person.Birthday.AddYears(DateTime.Today.Year - person.Birthday.Year);
        //    if (nextBirthday < DateTime.Today) { nextBirthday = nextBirthday.AddYears(1); }
        //    return (nextBirthday - DateTime.Today).Days;
        //}

        //public static string PersonFullName(string id)
        //{
        //    var person = SearchPerson(Parsing.StringToInt(id)[0]);
        //    return $"{person.FirstName} {person.SurnameName}";
        //}

        //public static string UpdatePerson(Person person, Person updated)
        //{
        //    return new Func<String>(() =>
        //    {
        //        if (CheckContactExistence(person))
        //        {
        //            people.Remove(person);
        //            people.Add(updated);
        //            return $"Contact updated successfully.\nOld data:\n {person.FirstName} " +
        //                   $"{person.SurnameName} | Birthday: {person.Birthday}" +
        //                   $"\nNew data:\n {updated.FirstName} {updated.SurnameName} " +
        //                   $"| Birthday: {updated.Birthday}";
        //        }
        //        else
        //        {
        //            return "Person doesn't exists.";
        //        }
        //    })();
        //}

        //public static string DeletePerson(Person person)
        //{
        //    return new Func<String>(() =>
        //    {
        //        if (CheckContactExistence(person))
        //        {
        //            people.Remove(person);
        //            return $"{person.FirstName} {person.SurnameName} successfully deleted.";
        //        }
        //        else
        //        {
        //            return "Person added.";
        //        }
        //    })();
        //}

        //private static Boolean CheckContactExistence(Person person)
        //{
        //    return new Func<Boolean>(() =>
        //    {
        //        foreach (var match in people)
        //        {
        //            if (match.FirstName.Equals(person.FirstName)
        //                && match.SurnameName.Equals(person.SurnameName)
        //                && match.Birthday.Equals(person.Birthday))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    })();
        //}
    }
}
