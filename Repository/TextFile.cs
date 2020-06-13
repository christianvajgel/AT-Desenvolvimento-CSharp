using People;
using System;
using System.IO;
using SystemWideOperations;

namespace Database
{
    public class TextFile
    {
        // xUnit [Fact] CheckCurrentId_TextFile()
        public static int CheckCurrentId()
        {
            return (Repository.peopleFromTextFile.Count == 0) ? 0 : Repository.peopleFromTextFile.Count;
        }

        // xUnit [Fact] GetFileName_TextFile()
        public static string GetFileName()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\people.txt";
        }

        // xUnit [Fact] Create_Read_TextFile() 
        public static Boolean ReadTextFile()
        {
            FileStream fileStream;

            if (!File.Exists(GetFileName()))
            {
                try
                {
                    fileStream = File.Create(GetFileName());
                    fileStream.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            var textFileSplitted = File.ReadAllText(GetFileName()).Split(';');

            for (var i = 0; i < textFileSplitted.Length - 1; i++)
            {
                var peopleData = textFileSplitted[i].Split(',');
                Repository.peopleFromTextFile.Add(new Person(
                                                             Parsing.StringToInt(peopleData[0])[0],
                                                             peopleData[1],
                                                             peopleData[2],
                                                             Convert.ToDateTime(peopleData[3])));
            }
            return true;
        }

        // xUnit [Fact] Close_TextFile() 
        public static Boolean CloseTextFile()
        {
            if (File.Exists(GetFileName()))
            {
                var pattern = String.Empty;
                foreach (var person in Repository.peopleFromTextFile)
                {
                    pattern += $"{person.Id},{person.FirstName},{person.Surname},{person.Birthday.ToShortDateString()};";
                }
                File.WriteAllText(GetFileName(), String.Empty);
                File.WriteAllText(GetFileName(), pattern);
                return true;
            }
            return false;
        }
    }
}
