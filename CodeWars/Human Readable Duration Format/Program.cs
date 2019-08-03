using System;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //our task in order to complete this Kata is to write a function which formats a duration, given as a number of seconds, in a human-friendly way.

        //The function must accept a non-negative integer.If it is zero, it just returns "now".
        //Otherwise, the duration is expressed as a combination of years, days, hours, minutes and seconds.

        //It is much easier to understand with an example:
        //formatDuration(62)    // returns "1 minute and 2 seconds"
        //formatDuration(3662)  // returns "1 hour, 1 minute and 2 seconds"

        //For the purpose of this Kata, a year is 365 days and a day is 24 hours.

        //Note that spaces are important.

        //Detailed rules
        //The resulting expression is made of components like 4 seconds, 1 year, etc.
        //In general, a positive integer and one of the valid units of time, separated by a space.
        //The unit of time is used in plural if the integer is greater than 1.

        //The components are separated by a comma and a space(", ").
        //Except the last component, which is separated by " and ", just like it would be written in English.

        //A more significant units of time will occur before than a least significant one. 
        //Therefore, 1 second and 1 year is not correct, but 1 year and 1 second is.

        //Different components have different unit of times.So there is not repeated units like in 5 seconds and 1 second.

        //A component will not appear at all if its value happens to be zero.
        //Hence, 1 minute and 0 seconds is not valid, but it should be just 1 minute.

        //A unit of time must be used "as much as possible".
        //It means that the function should not return 61 seconds, but 1 minute and 1 second instead. 
        //Formally, the duration specified by of a component must not be greater than any valid more significant unit of time.
        #endregion

        int seconds = int.Parse(Console.ReadLine());

        if (seconds <= 0)
        {
            Console.WriteLine("now");
            Environment.Exit(0);
        }

        var sec = 1;
        var minutes = sec * 60;
        var hours = minutes * 60;
        var days = hours * 24;
        var years = days * 365;

        var times = new int[] { years, days, hours, minutes, sec };
        var namesOfTimes = new string[] { "year", "day", "hour", "minute", "second" };

        var sb = new StringBuilder();

        for (int i = 0; i < times.Length; i++)
        {
            int currentTime = times[i];
            string currentName = namesOfTimes[i];

            bool isContained = currentTime <= seconds;
            if (isContained)
            {
                int totalTimes = seconds / currentTime;
                seconds -= totalTimes * currentTime;

                if (totalTimes > 1) // to see if you need to add an 's' at the end
                {
                    sb.Append($"{totalTimes} {currentName}s, ");
                }
                else
                {
                    sb.Append($"{totalTimes} {currentName}, ");
                }
            }
        }

        var outPut = sb.ToString();

        var charsToTrim = new char[] { ',', ' ' };

        outPut = outPut.Trim(charsToTrim);

        int indexOfLastComma = outPut.LastIndexOf(",");

        var newSB = new StringBuilder(outPut);
        newSB[indexOfLastComma] = ' ';

        outPut = newSB.ToString();
        outPut = outPut.Insert(indexOfLastComma + 1, "and");

        Console.WriteLine(outPut);
    }
}