using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
public class Program
{   //TODO: double negative into a plus and expand brackets with a minus
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
        var inputAsList = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var bracketIndex = inputAsList.IndexOf("(");
        while (bracketIndex != -1)
        {
            inputAsList = ExpandBrackets(inputAsList);
            bracketIndex = inputAsList.IndexOf("(");
        }

        var result = double.Parse(BEDMAS(inputAsList)[0]);

        //var numbers = GetNumber(input);
        //var numbersAndIndex = GetNumbersAndIndex(input, numbers);


        //get the brackets clear
        //find nums and ops
        //do the operations
        //do the same with cleared brackets

        return result;
    }

    public static List<string> ExpandBrackets(List<string> input) //TODO: if there is a negative infront of brackets
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

        var range = input.GetRange(smallestStartIndex + 1, smallestDifference - 1);
        //expand the brackets
        var newRange = BEDMAS(range);

        // make range into a string

        //fix the input by removing old and putting in new
        input.RemoveRange(smallestStartIndex, smallestDifference + 1);
        input.InsertRange(smallestStartIndex, newRange);

        //return range;
        //find the range and remove it
        // calculate 
        //repeat

        return input;
    }

    public static List<string> BEDMAS(List<string> range)
    {
        //var outPut = new List<string>();

        var numbers = GetNumbers(range);
        var operators = GetOperators(range);

        var result = new List<string> { EDMAS(numbers, operators).ToString() };
        return result;

        //return outPut;
    }

    public static double EDMAS(Dictionary<int, double> numbers, Dictionary<int, string> operators)
    {
        // need to make them in EDMAS Format
        bool containsExponent = operators.Values.Contains("^"); // check if any exponents -> resolve all then continue on EDMAS
        while (containsExponent)
        {
            ShortenExpression(numbers, operators, "^");

            containsExponent = operators.Values.Contains("^");
        }

        bool containsDivision = operators.Values.Contains("/");
        while (containsDivision)
        {
            ShortenExpression(numbers, operators, "/");

            containsDivision = operators.Values.Contains("/");
        }

        bool containsMultiplication = operators.Values.Contains("*");
        while (containsMultiplication)
        {
            ShortenExpression(numbers, operators, "*");

            containsMultiplication = operators.Values.Contains("*");
        }

        bool containsAddition = operators.Values.Contains("+");
        while (containsAddition)
        {
            ShortenExpression(numbers, operators, "+");

            containsAddition = operators.Values.Contains("+");
        }

        bool containsSubtraction = operators.Values.Contains("-");
        while (containsSubtraction)
        {
            ShortenExpression(numbers, operators, "-");

            containsSubtraction = operators.Values.Contains("-");
        }

        return numbers[0];
    }

    public static void ShortenExpression(Dictionary<int, double> numbers, Dictionary<int, string> operators, string symbol) // allows me to not copy paste code for each operator: removing the 2 addends and the operator 
    {
        //find the first occurance of the symbol in the operator dict (values) 
        int indexOfOperator = -1;
        foreach (var key in operators.Keys)
        {
            bool rightOperator = operators[key] == symbol;
            if (rightOperator)
            {
                indexOfOperator = key;
                operators.Remove(indexOfOperator);
                break;
            }
        }

        //Find the closest smaller than indexOfOp key in nums = the first Num (before operator)
        int indexOfFirstNum = int.MinValue;
        double firstNum = double.MinValue;
        foreach (var key in numbers.Keys.Where(key => key < indexOfOperator))
        {
            firstNum = numbers[key];
            indexOfFirstNum = key; // to insert the result back into numbers
        }

        numbers.Remove(indexOfFirstNum);

        //Find the closest bigget than indexOfOp key in nums = the second num (after operator)
        int indexOfSecondNum = int.MinValue;
        double secondNum = double.MinValue;
        foreach (var key in numbers.Keys.Where(key => key > indexOfOperator))
        {
            secondNum = numbers[key];
            indexOfSecondNum = key;
        }
        numbers.Remove(indexOfSecondNum);

        double resultNum = 0;

        switch (symbol)
        {
            case "^":
                resultNum = Exponentiation(firstNum, secondNum);
                break;

            case "/":
                resultNum = Division(firstNum, secondNum);
                break;

            case "*":
                resultNum = Multiplication(firstNum, secondNum);
                break;

            case "+":
                resultNum = Addition(firstNum, secondNum);
                break;

            case "-":
                resultNum = Subtraction(firstNum, secondNum);
                break;
            default:
                break;
        }

        // see if between the indexs of the firstNum and secondNum, there is a nother operator, if so its a negative -> make the result negative
        for (int index = indexOfFirstNum; index <= indexOfSecondNum; index++)
        {
            if(operators.ContainsKey(index))
            {
                operators.Clear();
                resultNum = 0 - resultNum;
                break;
            }

        }

        //Inset the result in the place of the now removed 2 numbers and operator
        numbers[indexOfFirstNum] = resultNum;
    }

    public static Dictionary<int, string> GetOperators(List<string> range)
    {
        var operators = new Dictionary<int, string>(); // key = index, value = operator

        var possibleOperators = new List<string>() { "+", "-", "*", "/", "^" };

        for (int index = 0; index < range.Count(); index++)
        {
            string currentString = range[index];

            bool isOperator = possibleOperators.Contains(currentString);
            if (isOperator)
            {
                operators[index] = currentString;
            }
        }

        return operators;
    }

    public static Dictionary<int, double> GetNumbers(List<string> range)
    {
        var numbers = new Dictionary<int, double>(); // key = index, value = the number

        string regexPattern = @"\d+(\.\d+)?";
        var regex = new Regex(regexPattern);

        for (int index = 0; index < range.Count(); index++)
        {
            var currentString = range[index];

            bool isNum = regex.IsMatch(currentString);
            if (isNum)
            {
                double number = double.Parse(currentString);
                numbers[index] = number;
            }
        }

        return numbers;
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