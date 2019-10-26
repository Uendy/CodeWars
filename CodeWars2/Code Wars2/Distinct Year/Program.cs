using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //The year of 2013 is the first year after the old 1987 with only distinct digits.

        //Now your task is to solve the following problem: given a year number, 
        //find the minimum year number which is strictly larger than the given one and has only distinct digits.

        int year = int.Parse(Console.ReadLine());

        var distinctYear = FindNextDistinctYear(year);

        Console.WriteLine(distinctYear);
    }

    public static object FindNextDistinctYear(int year)
    {
        while (true)
        {
            ++year;

            string yearAsString = year.ToString();
            int distinctNumbers = yearAsString.Distinct().Count();
            if (distinctNumbers == 4)
            {
                return year;
            }

        }

    }
}
