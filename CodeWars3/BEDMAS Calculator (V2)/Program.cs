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
        //Find all ranges and gets the smallest one, the shortest distance from "(" to ")" and starts with it
        var indexOfStartBrackets = new List<int>(); // get all the '(' by index
        int indexOfStart = input.IndexOf("(");
        while (indexOfStart >= 0)
        {
            indexOfStartBrackets.Add(indexOfStart);
            indexOfStart = input.IndexOf("(", indexOfStart + 1);
        }

        var indexOfEndBrackets = new List<int>(); // get all the ')' by index
        int indexOfEnd = input.IndexOf(")");
        while (indexOfEnd >= 0)
        {
            indexOfEndBrackets.Add(indexOfEnd);
            indexOfEnd = input.IndexOf(")", indexOfEnd + 1);
        }

        int smallestDifference = int.MaxValue;
        int smallestStartIndex = int.MaxValue;

        for (int startBracket = 0; startBracket < indexOfStartBrackets.Count(); startBracket++) // find the smallest distance between to brackets
        {
            int startIndex = indexOfStartBrackets[startBracket];

            for (int endBracket = 0; endBracket < indexOfEndBrackets.Count(); endBracket++)
            {
                int endIndex = indexOfEndBrackets[endBracket];

                int difference = endIndex - startIndex;

                bool shortestDifference = difference < smallestDifference;
                if (shortestDifference)
                {
                    smallestDifference = difference;
                    smallestStartIndex = startIndex;
                }
            }
        }

        var range = input.GetRange(smallestStartIndex, smallestDifference);
        //expand the brackets
        var newRange = BEDMAS(range);

        // make range into a string

        //fix the input by removing old and putting in new
        input.RemoveRange(smallestStartIndex, smallestDifference);
        input.InsertRange(smallestStartIndex, newRange);
        
        


        //return range;
        //find the range and remove it
        // calculate 
        //repeat

        return input;
    }

    public static List<string> BEDMAS(List<string> range)
    {
        var outPut = new List<string>();

        var numbers = GetNumbers(range);
        var operators = GetOperators();

    }

    public static List<string> GetOperators(List<string> range)
    {
        var operators = new List<string>();

        var possibleOperators = new List<string>() { "+", "-", "*", "/", "^" };

        foreach (var item in range)
        {
            bool isOperator = possibleOperators.Contains(item);
            operators.Add(item);
        }

        return operators;
    }

    public static List<double>GetNumbers(List<string> range)
    {
        throw new NotImplementedException();
    }
}