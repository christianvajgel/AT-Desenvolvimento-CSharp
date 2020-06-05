using System;
using System.Linq;
using System.Collections.Generic;

namespace ClassLibrary_at_csharp
{
    public class Repository : IRepository
    {
        public static List<Person> people = new List<Person>();

        // CREATE
        public string AddPerson(Person person)
        {
            return new Func<String>(() =>
            {
                if (CheckContactExistence(person)) { return "Person already exists."; }
                else { 
                    //people.Add(person); return "Person added."; }
                    people.Add(person); return TextFile.AppendTextToFile(person); }
            })();
        }

        // READ
        public IEnumerable<Person> ReadPeople()
        {
            throw new NotImplementedException();
        }

        // UPDATE - create menu - show list 
        public string UpdatePerson(Person person, int id)
        {
            return new Func<String>(() =>
            {
                var result = SearchPerson(id);
                if (CheckContactExistence(result))
                {
                    TextFile.peopleFromTextFile[result.Id] = person;
                    return $"Contact updated successfully.\nOld data:\n {result.FirstName} " +
                           $"{result.Surname} | Birthday: {result.Birthday.ToShortDateString()}" +
                           $"\nNew data:\n {person.FirstName} {person.Surname} " +
                           $"| Birthday: {person.Birthday.ToShortDateString()}";
                }
                else
                {
                    return "Person doesn't exists.";
                }
            })();
        }

        // DELETE - create menu - change everyone ID after delete process
        public string DeletePerson(Person person)
        {
            return new Func<String>(() =>
            {
                var result = SearchPerson(person.Id);
                if (result != null && result == person)
                {
                    TextFile.peopleFromTextFile.Remove(person);
                    return $"{person.FirstName} {person.Surname} successfully deleted.";
                }
                else
                {
                    return "Person does not exists.";
                }
            })();
        }

        // Search for keywords
        public IEnumerable<Person> SearchPeople(string termFirstName, string termSurname)
        {
            return TextFile.peopleFromTextFile.Where(person =>
                person.FirstName.Contains(termFirstName, StringComparison.InvariantCultureIgnoreCase) ||
                person.Surname.Contains(termSurname, StringComparison.InvariantCultureIgnoreCase));
        }

        // Return people who is celebrating birthday today
        public IEnumerable<Person> BirthdayPeopleOfTheDay()
        {
            // iterate over txt to compare each object.Birthday with today's date
            
            throw new NotImplementedException();
        }


        public int DateCountdown(string id)
        {
            return new Func<int>(() => { return CalculateDays(SearchPerson(Parsing.StringToInt(id)[0])); })();
        }

        public static Person SearchPerson(int id)
        {
            //var PersonObject = new Person();
            foreach (var match in TextFile.peopleFromTextFile)
            {
                if (match.Id == id) { return TextFile.peopleFromTextFile[match.Id]; }
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
                foreach (var match in TextFile.peopleFromTextFile)
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
