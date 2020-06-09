using System;

public class RandomData
{
	public static string[] names = new string[5] { "John", "Mark", "Bob", "Linda", "Mel" };
	public static string[] surnames = new string[5] { "Doe", "Hungry", "Tired", "Sleepy", "Ranch" };

    public static int RandomInt(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    public static DateTime RandomDate() 
    {
        return new Func<DateTime>(() =>
        {
            var completeDate = "";
            var finalDate = new DateTime();
            do
            {
                var day = RandomInt(1,28);
                var month = RandomInt(1, 12);
                var year = RandomInt(1, 9999);
                completeDate = year + "/" + month + "/" + day;
                if (DateValidation(completeDate) == default)
                {
                    Console.WriteLine("Invalid date.\nTry again.");
                    ClearScreen(false);
                }
                else
                {
                    finalDate = ConvertToDateTimeObject(day, month, year)[0];
                }
            } while (DateValidation(completeDate) == default);
            return finalDate;
        })();
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
