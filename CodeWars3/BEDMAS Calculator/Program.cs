using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //iven a string of characters and symbols, calculate the expected result. The string consists of numbers, and the operators:

        /// division
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

        string input = Console.ReadLine().Trim();

        var result = ApplyCalculator(input);

        Console.WriteLine(result);
        
    }

    public static object ApplyCalculator(string input)
    {
        var result = 0;


        var indexOfBracket = input.IndexOf('(');
        while (indexOfBracket != -1) // cycle through all brackets and solve them
        {

            int indexOfClosedBracket = input.IndexOf(')');
            int bracketSpan = indexOfClosedBracket - indexOfBracket;

            var range = input.Substring(indexOfBracket, bracketSpan);

            var operatorsInBrackets = GetOperators(range);
            var numbersInBrackets = GetNumber(range);

            // need to make them in EDMAS Format

            var newRange = string.Empty; // fill this with the uncovered brackets

            //When you make the methods for each operator fill them in here for whats in the brackets

            input = input.Replace(range, newRange);
            indexOfBracket = input.IndexOf('('); // check for more brackets, I wont cover double brackets
        }

        return result;
    }

    public static List<double> GetNumber(string input)
    {
        var numbers = input
            .Split(new[] { '+', '-', '/', '*', '^', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Select(double.Parse)
            .ToList();

        return numbers;
    }

    public static List<char> GetOperators(string input)
    {
        var operators = new List<char>();
        var inputAsArray = input.ToCharArray();
        foreach (var item in inputAsArray)
        {
            bool isOperator = item == '+' || item == '-' || item == '/' || item == '*' || item == '^' || item == '(' || item == ')';
            if (isOperator)
            {
                operators.Add(item);
            }
        }

        return operators;
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