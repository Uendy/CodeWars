using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        #region
        //Given a string of characters and symbols, calculate the expected result. The string consists of numbers, and the operators:

        // division
        //+ addition
        //- subtraction
        //\*multiplication
        //^ power of
        //As well as the brackets()

        //Numbers can be integers or doubles.

        //Assume the string is of the correct format(no missing brackets, unmatched operators). 
        //The format of the string can also have optional whitespace between numbers and symbols, so the following are equivalent:

        //"3+4*2"
        //"3 +                             4*   2"

        // ! Dosen't support negative numbers
        #endregion

        Console.WriteLine("Welcome to my calculator");

        Console.WriteLine("You can use any of the following functions:");
        Console.WriteLine("- Addition (+)");
        Console.WriteLine("- Subtraction (-)");
        Console.WriteLine("- Multiplication (*)");
        Console.WriteLine("- Division (/)");
        Console.WriteLine("- Exponent (^)");

        Console.WriteLine("You can input and recieve results as decimal numbers aswell");

        Console.Write("Input your function here: ");

        string input = Console.ReadLine();

        var result = ApplyCalculator(input);

        Console.WriteLine($"= {result}");
        
    }

    public static double ApplyCalculator(string input)
    {
        // cycle through all brackets and solve them
        var indexOfBracket = input.IndexOf('(');
        while (indexOfBracket != -1) 
        {
            string range = FindInnerMostBrackets(input); // find the shortest distance from '(' to ')' = the first brackets we have to expand

            string expanded = ExpandBrackets($"({range})");
            //When you make the methods for each operator fill them in here for whats in the brackets

            input = input.Replace(range, expanded);
            indexOfBracket = input.IndexOf('('); // check for more brackets, I wont cover double brackets
        }

        //For the expanded expression without any brackets
        var numbers = GetNumber(input);
        var operators = GetOperators(input);

        double result = EDMAS(operators, numbers); 

        return result;
    }

    public static List<double> GetNumber(string input)
    {
        //got the idea to get the numbers via REGEX
        //var numbers = input
        //    .Split(new[] { '+', '-', '/', '*', '^', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(x => x.Trim())
        //    .Select(double.Parse)
        //    .ToList();
        var regex = new Regex();

        var numbers = new List<double>();

        return numbers;
    }

    public static List<char> GetOperators(string input)
    {
        var operators = new List<char>();
        var inputAsArray = input.ToCharArray();

        for (int index = 0; index < inputAsArray.Count(); index++)
        {
            char currentSymbol = inputAsArray[index];

            bool isOperator = currentSymbol == '+' || currentSymbol == '-' || currentSymbol == '/' || currentSymbol == '*' || currentSymbol == '^';
            if (isOperator)
            {
                bool negativeNum = currentSymbol == '-' && char.IsDigit(inputAsArray[index + 1]); // to not count negative nums as an operator
                if (!negativeNum)
                {
                    operators.Add(currentSymbol);
                }
            }
        }
        return operators;
    }

    public static string FindInnerMostBrackets(string input)
    {
        var indexOfStartBrackets = new List<int>(); // get all the '(' by index
        int indexOfStart = input.IndexOf('(');
        while (indexOfStart >= 0)
        {
            indexOfStartBrackets.Add(indexOfStart);
            indexOfStart = input.IndexOf('(', indexOfStart + 1);
        }

        var indexOfEndBrackets = new List<int>(); // get all the ')' by index
        int indexOfEnd = input.IndexOf(')');
        while (indexOfEnd >= 0)
        {
            indexOfEndBrackets.Add(indexOfEnd);
            indexOfEnd = input.IndexOf(')', indexOfEnd + 1);
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

        string range = input.Substring(smallestStartIndex, smallestDifference);

        return range;
    }

    public static string ExpandBrackets(string range) // returns the brackets expression as expanded
    {
        var operatorsInBrackets = GetOperators(range);
        var numbersInBrackets = GetNumber(range);

        range = EDMAS(operatorsInBrackets, numbersInBrackets).ToString();

        var newRange = new StringBuilder(); // fill this with the uncovered brackets
        for (int indexOfNum = 0; indexOfNum < numbersInBrackets.Count() - 2; indexOfNum++) // could be wrong, test it out
        {
            newRange.Append($"{numbersInBrackets[indexOfNum]} {operatorsInBrackets[indexOfNum]}");
        }
        newRange.Append(numbersInBrackets[numbersInBrackets.Count() - 1]);

        return newRange.ToString();
    }

    public static double EDMAS(List<char> operators, List<double> numbers)
    {
        // need to make them in EDMAS Format
        bool containsExponent = operators.Contains('^'); // check if any exponents -> resolve all then continue on EDMAS
        while (containsExponent)
        {
            ShortenExpression(numbers, operators, '^');

            containsExponent = operators.Contains('^');
        }

        bool containsDivision = operators.Contains('/');
        while (containsDivision)
        {
            ShortenExpression(numbers, operators, '/');

            containsDivision = operators.Contains('/');
        }

        bool containsMultiplication = operators.Contains('*');
        while (containsMultiplication)
        {
            ShortenExpression(numbers, operators, '*');

            containsMultiplication = operators.Contains('*');
        }

        bool containsAddition = operators.Contains('+');
        while (containsAddition)
        {
            ShortenExpression(numbers, operators, '+');

            containsAddition = operators.Contains('+');
        }

        bool containsSubtraction = operators.Contains('-');
        while (containsSubtraction)
        {
            ShortenExpression(numbers, operators, '-');

            containsSubtraction = operators.Contains('-');
        }

        return numbers[0];
    }

    public static void ShortenExpression(List<double> numbers, List<char> operators, char symbol) // allows me to not copy paste code for each operator: removing the 2 addends and the operator 
    {
        int indexOfExponent = operators.IndexOf(symbol);

        double firstNum = numbers[indexOfExponent]; // get the number before the exponent op
        double secondNum = numbers[indexOfExponent + 1]; // get the number afte the exponent op

        double resultNum = 0;

        switch (symbol)
        {
            case '^':
                resultNum = Exponentiation(firstNum, secondNum);
                break;

            case '/':
                resultNum = Division(firstNum, secondNum);
                break;

            case '*':
                resultNum = Multiplication(firstNum, secondNum);
                break;

            case '+':
                resultNum = Addition(firstNum, secondNum);
                break;

            case '-':
                resultNum = Subtraction(firstNum, secondNum);
                break;
            default:
                break;
        }

        operators.Remove(symbol); // replace the past expression of num1 ^ num2 with the result
        numbers.RemoveAt(indexOfExponent);
        numbers.RemoveAt(indexOfExponent);
        numbers.Insert(indexOfExponent, resultNum);
    }

    public static double Addition(double firstNum, double secondNum)
    {
        double sum = firstNum + secondNum;
        return sum;
    }

    public static double Subtraction(double firstNum, double secondNum)
    {
        double sum = firstNum - secondNum;
        return sum;
    }

    public static double Multiplication(double firstNum, double secondNum)
    {
        double sum = firstNum * secondNum;
        return sum;
    }

    public static double Division(double firstNum, double secondNum)
    {
        double sum = firstNum / secondNum;
        return sum;
    }

    public static double Exponentiation(double firstNum, double secondNum)
    {
        double sum = Math.Pow(firstNum, secondNum);
        return sum;
    }
}