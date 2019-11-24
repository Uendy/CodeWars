using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        var formattedInput = SpaceInput(input);
    }

    public static string SpaceInput(string input) // get all the parts to be spaced with a single inbetween
    {
        bool containsMoreSpaces = input.Contains("  "); // gets all multiple spaces into singles
        while (containsMoreSpaces)
        {
            input.Replace("  ", " ");
            containsMoreSpaces = input.Contains("  ");
        }

        var operators = new List<char>() { '+', '*', '/', '^' }; // missing '.' and '-'
        var sb = new StringBuilder();

        var inputAsArray = input.ToCharArray();
        for (int index = 0; index < inputAsArray.Count(); index++)
        {
            char currentChar = inputAsArray[index];


        }

        var result = sb.ToString();
        return result;
    }
}