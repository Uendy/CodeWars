using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        //https://www.codewars.com/kata/meeting/train/csharp

        //makes this string uppercase
        //gives it sorted in alphabetical order by last name.
        //When the last names are the same, sort them by first name.
        //Last name and first name of a guest come in the result between parentheses separated by a comma.

        //Ex: 
        //input = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        //output = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"

        string input = Console.ReadLine();
        var people = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToUpper()).ToList();

        var listOfCoworkers = new List<Coworker>();

        foreach (var person in people)
        {
            var names = person.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}