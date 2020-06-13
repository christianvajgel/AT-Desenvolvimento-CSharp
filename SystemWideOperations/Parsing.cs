using System;
using System.Threading;
using System.Collections.Generic;

namespace SystemWideOperations
{
    public static class Parsing
    {
        // xUnit [Fact] StringToInt_Valid(string evaluate) 
        //              StringToInt_NotValid(string evaluate)
        public static List<int> StringToInt(string evaluate)
        {
            if (Validations.StringValidation(evaluate)[1].Equals("valid"))
            {
                List<int> result = new List<int>();
                try
                {
                    var number = Int32.Parse(evaluate);
                    result.Add(number);
                    return result;
                }
                catch (FormatException)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        // xUnit [Fact] ConvertToDateTimeObject_Valid(string day, string month, string year)  
        //              ConvertToDateTimeObject_NotValid(string day, string month, string year)
        public static List<DateTime> ConvertToDateTimeObject(string day, string month, string year)
        {
            var evaluate = year + "/" + month + "/" + day;
            if (Validations.DateValidation(evaluate) != default)
            {
                List<DateTime> result = new List<DateTime>();
                try
                {
                    result.Add(new DateTime(StringToInt(year)[0], StringToInt(month)[0], StringToInt(day)[0],
                    new System.Globalization.CultureInfo(Thread.CurrentThread.CurrentCulture.Name, false).Calendar));
                    return result;
                }
                catch (FormatException)
                {
                    result.Add(default);
                    return result;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
