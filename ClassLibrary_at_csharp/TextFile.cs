using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Linq;

namespace ClassLibrary_at_csharp
{
    public class TextFile
    {
        public static List<Person> textFileData = new List<Person>();
        public static List<Person> peopleFromTextFile = new List<Person>();

        public static void InitializeTextFile()
        {
            if (ReadTextFile() != null)
            {
                peopleFromTextFile = ReadTextFile();
                foreach (var p in peopleFromTextFile)
                {
                    Console.WriteLine($"{p.Id} {p.FirstName} {p.Surname} {p.Birthday}\n");
                }
                Console.WriteLine(peopleFromTextFile.Count());
            }

        }

        private static string GetFileName()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\people.txt";
        }

        // CREATE
        public static string AppendTextToFile(Person person)
        {
            var fileName = GetFileName();
            var pattern = $"{person.Id},{person.FirstName},{person.Surname},{person.Birthday.ToShortDateString()}";
            try
            {
                File.AppendAllText(fileName, pattern);
                //ReadTextFile();
                return "Person added.";
            }
            catch (IOException)
            {
                return "An error occured with the text file.";
            }
        }

        // READ
        public static List<Person> ReadTextFile()
        {
            FileStream fileStream;
            if (!File.Exists(GetFileName()))
            {
                fileStream = File.Create(GetFileName());
                fileStream.Close();
                return null;
            }
            var textFileSplitted = File.ReadAllText(GetFileName()).Split(';');

            //for (var i = 0; i < textFileSplitted.Length - 1; i++) 
            for (var i = 0; i < textFileSplitted.Length; i++)
            {
                var peopleData = textFileSplitted[i].Split(',');
                var dt = peopleData[3];
                if (dt.EndsWith('0') && !dt[6].Equals('/'))
                {
                    dt = dt.Remove(dt.Length - 1);
                }

                textFileData.Add(new Person(
                                      Parsing.StringToInt(peopleData[0])[0],
                                      peopleData[1],
                                      peopleData[2],
                                      //DateTime.Parse(peopleData[3])));
                                      Convert.ToDateTime(dt)));
            }

            //foreach (var p in peopleFromTextFile)
            //{
            //    Console.WriteLine($"{p.Id} {p.FirstName} {p.Surname} {p.Birthday}\n");
            //}
            return textFileData;
        }

        // UPDATE
        public string UpdatePerson(Person person, Person updated)
        {
            return new Func<String>(() =>
            {
                if (Repository.CheckContactExistence(person))
                {
                    peopleFromTextFile.Remove(person);
                    peopleFromTextFile.Add(updated);
                    return $"Contact updated successfully.\nOld data:\n {person.FirstName} " +
                           $"{person.Surname} | Birthday: {person.Birthday.ToShortDateString()}" +
                           $"\nNew data:\n {updated.FirstName} {updated.Surname} " +
                           $"| Birthday: {updated.Birthday.ToShortDateString()}";
                }
                else
                {
                    return "Person doesn't exists.";
                }
            })();
        }

        // DELETE
    }
}
