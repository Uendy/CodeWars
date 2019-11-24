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

        var result = ApplyCalculator(formattedInput);

        Console.WriteLine(result);
    }

    

    public static string WhiteSpacesFormatting(string input)
    {
        bool containsMoreSpaces = input.Contains("  "); // gets all multiple spaces into singles
        while (containsMoreSpaces)                      // ex: "1    + 7" -> "1 + 7" 
        {
            input = input.Replace("  ", " ");
            containsMoreSpaces = input.Contains("  ");
        }

        return input;
    }

    public static string SpaceInput(string input) // get all the parts to be spaced with a single inbetween
    {
        input = WhiteSpacesFormatting(input);

        var operators = new List<char>() { '+', '-', '*', '/', '^', '(', ')' }; 
        var sb = new StringBuilder();


        var inputAsArray = input.ToCharArray();
        for (int index = 0; index < inputAsArray.Count(); index++)
        {
            char currentChar = inputAsArray[index];

            bool numberOrDecimal = char.IsDigit(currentChar) || currentChar == '.';
            if (numberOrDecimal)
            {
                sb.Append(currentChar);
            }

            bool isOperators = operators.Contains(currentChar);
            if (isOperators)
            {
                bool startsWithNegative = index == 0 && currentChar == '-'; // allow the - to be added to the number if at start
                if (startsWithNegative) // not sure I will keep this here
                {
                    sb.Append(currentChar);
                    continue;
                }

                sb.Append($" {currentChar} ");
            }
        }

        var result = sb.ToString();

        result = WhiteSpacesFormatting(result);
        return result;
    }
    public static object ApplyCalculator(string input)
    {
        double result = 0.0;


        var inputAsList = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var bracketIndex = inputAsList.IndexOf("(");
        while (bracketIndex != -1)
        {
            var expandedInput = ExpandBrackets(inputAsList);
            //do check again
        }
        //var numbers = GetNumber(input);
        //var numbersAndIndex = GetNumbersAndIndex(input, numbers);


        //get the brackets clear
        //find nums and ops
        //do the operations
        //do the same with cleared brackets

        return result;
    }

    public static List<string> ExpandBrackets(List<string> input)
    {
        //find the range and remove it
        // calculate 
        //repeat

        return input;
    }

    //public static List<string> GetNumber(string input)
    //{
    //    var numbers = new List<string>();

    //    string regexPattern = @"[-]?\d+(\.\d+)?"; // took me ages to figure this out
    //    var regex = new Regex(regexPattern);

    //    var matches = regex.Matches(input);
    //    foreach (Match match in matches)
    //    {
    //        numbers.Add(match.ToString());
    //    }

    //    return numbers;
    //}
    //public static Dictionary<double, int> GetNumbersAndIndex(string input, List<string> numbers)
    //{
    //    var numsAndIndex = new Dictionary<double, int>();

    //    foreach (var num in numbers)
    //    {
    //        input.IndexOf()
    //    }

    //    return numsAndIndex;
    //}


}