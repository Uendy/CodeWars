using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        //Kata address: https://www.codewars.com/kata/56a14b6b56e5917073000022/train/csharp

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
        var list = GetElements(input);
        list = ExpandBrackets(list);

        double result = EDMAS(list);
        Console.WriteLine(result);
    }

    public static List<string> GetElements(string input) // returns all operators and numbers into a list with correct order
    {
        var list = new List<string>();

        var operators = new List<string>() { "+", "-", "*", "/", "^", "(", ")" };

        var inputAsArray = input.ToCharArray();

        var sb = new StringBuilder();

        for (int index = 0; index < inputAsArray.Count(); index++)
        {
            var currentChar = inputAsArray[index].ToString();

            bool isOperator = operators.Contains(currentChar);
            if (isOperator)
            {
                //empty collected sb into a string and add to list
                var nextNum = sb.ToString();
                list.Add(nextNum);
                sb.Clear(); // what if it ends in )

                list.Add(currentChar);
            }
            else
            {
                sb.Append(currentChar);

                //adding last num to to list
                bool lastIndex = index == inputAsArray.Count() - 1;
                if (lastIndex)
                {
                    var lastNum = sb.ToString();
                    list.Add(lastNum);
                }
            }

        }

        // removes any excess white spaces and all white spaces in general
        list = list.Select(x => x.Trim()).Where(x => x != " ").Where(y => y != "").ToList();


        return list;
    }
    public static List<string> ExpandBrackets(List<string> list)
    {
        //TODO Redo this and all will be good
        bool containsBracket = list.Contains("(");
        while (containsBracket)
        {
            //get all the "("
            var startBrackets = new List<int>();
            int indexOfStart = list.IndexOf("(");
            while (indexOfStart != -1)
            {
                startBrackets.Add(indexOfStart);
                indexOfStart = list.IndexOf("(", indexOfStart + 1);
            }

            //get all the ")"
            var endBrackets = new List<int>();
            int indexOfEnd = list.IndexOf(")");
            while (indexOfEnd != -1)
            {
                endBrackets.Add(indexOfEnd);
                indexOfEnd = list.IndexOf(")", indexOfEnd + 1);
            }
            int shortestDistance = int.MaxValue;

            //find the innerMost Brackets and start from there
            foreach (var startIndex in startBrackets)
            {
                foreach (var endIndex in endBrackets)
                {
                    int distance = endIndex - startIndex;
                    bool newShorterDistance = shortestDistance > distance && distance > 0;
                    if (newShorterDistance)
                    {
                        shortestDistance = distance;
                        indexOfStart = startIndex;

                    }
                }
            }

            var range = list.GetRange(indexOfStart + 1, shortestDistance - 1);
            list.RemoveRange(indexOfStart, shortestDistance + 1);

            bool emptyBrackets = range.Count() <= 0;
            if (!emptyBrackets)
            {
                var result = EDMAS(range);

                list.Insert(indexOfStart, result.ToString());
            }

            containsBracket = list.Contains("(");
        }

        return list;
    }
    public static double EDMAS(List<string> range)
    {
        var operators = new List<string>() { "^", "/", "*", "-", "+" };

        foreach (var op in operators) // check each op in order
        {
            range = GetNegativeNumbers(range, operators); // fixes all problems stemming from a minus

            bool containsOp = range.Contains(op);
            while (containsOp) //get all the ops before moving on to the next op
            {
                if (range.Count() == 1) // return the only number
                {
                    return double.Parse(range[0]);
                }

                int indexOfOp = range.IndexOf(op);

                int indexOfFirstNum = indexOfOp - 1;
                int indexOfSecondNum = indexOfOp + 1;
                int distance = indexOfSecondNum - indexOfFirstNum;

                double firstNum = double.Parse(range[indexOfFirstNum]);
                double secondNum = double.Parse(range[indexOfSecondNum]);

                double result = 0;

                switch (op) //execute the math
                {
                    case "^":
                        result = Math.Pow(firstNum, secondNum);
                        break;

                    case "/":
                        result = firstNum / secondNum;
                        break;

                    case "*":
                        result = firstNum * secondNum;
                        break;

                    case "-":
                        result = firstNum - secondNum;
                        break;

                    case "+":
                        result = firstNum + secondNum;
                        break;

                    default:
                        break;
                }

                //remove previous range and insert new num
                range.RemoveRange(indexOfFirstNum, distance + 1);

                bool negativeNum = result < 0;
                if (negativeNum)
                {
                    if (range.Count() == 0) // as it inserts it properly and dosent, seperate the minus giving an infinite loop of containing minus operator
                    {
                        range.Insert(0, result.ToString());
                    }
                    else
                    {
                        range.Insert(indexOfOp - 1, "-");
                        range.Insert(indexOfOp, Math.Abs(result).ToString());
                    }
                }
                else
                {
                    range.Insert(indexOfOp - 1, result.ToString());
                }
                containsOp = range.Contains(op);
            }
        }

        double resultFromRange = double.Parse(range[0]);
        return resultFromRange;
    }

    public static List<string> GetNegativeNumbers(List<string> range, List<string> operators)
    {
        bool leadingMinus = range[0] == "-"; // starts with - -> firstNum is negative
        if (leadingMinus)
        {
            range[1] = (0 - double.Parse(range[1])).ToString();
            range.RemoveAt(0);
        }

        for (int index = 1; index < range.Count(); index++) // if - then - again just make the num positive
        {
            var currentElement = range[index];
            bool currentMinus = currentElement == "-";
            if (currentMinus)
            {
                bool previousElementIsOperator = operators.Contains(range[index - 1]); // as if its a number then the - is an operator
                if (previousElementIsOperator)
                {
                    range[index + 1] = (0 - double.Parse(range[index + 1])).ToString();
                    range.RemoveAt(index);
                }
            }
        }
        return range;
    }
}