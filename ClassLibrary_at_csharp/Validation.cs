using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary_at_csharp
{
    public static class Validations
    {
        public static List<string> StringValidation(string evaluate)
        {
            List<string> validations = new List<string>();

            var stringOnlyLetters = new Func<string>(() =>
            {
                return Regex.IsMatch(evaluate, @"^[a-zA-Z]+$") ? "valid" : "Text contains numbers or invalid characters.";
            })();
            var stringOnlyNumber = new Func<string>(() =>
            {
                return Regex.IsMatch(evaluate, @"^[0-9]+$") ? "valid" : "Text must contains only integers numbers.";
            })();
            validations.Add(stringOnlyLetters);
            validations.Add(stringOnlyNumber);
            return validations;
        }

        public static DateTime DateValidation(string evaluate)
        {
            return new Func<DateTime>(() =>
            {
                var dateParsed = new DateTime();

                try
                {
                    dateParsed = DateTime.Parse(evaluate);
                }
                catch (Exception)
                {
                    dateParsed = default;
                }
                return dateParsed;
            })();
        }
    }
}
