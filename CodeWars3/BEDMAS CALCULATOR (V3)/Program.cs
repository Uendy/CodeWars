using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
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
                    bool newShorterDistance = shortestDistance > distance;
                    if (newShorterDistance)
                    {
                        shortestDistance = distance;
                        indexOfStart = startIndex;

                    }
                }
            }

            var range = list.GetRange(indexOfStart + 1, shortestDistance - 1);
            var result = EDMAS(range);

            //remove the past range with the result
            list.RemoveRange(indexOfStart, shortestDistance + 1);

            bool resultIsNegative = 0 > result; // to seperate the minus op from the number
            if (resultIsNegative)
            {
                list.Insert(indexOfStart, "-");
                list.Insert(indexOfStart, Math.Abs(result).ToString());
            }
            else
            {
                list.Insert(indexOfStart, result.ToString());
            }

            containsBracket = list.Contains("(");
        }

        return list;
    }
    public static double EDMAS(List<string> range)
    {
        bool beginsWithMinus = range[0] == "-";
        if (beginsWithMinus)
        {
            range.Insert(0, "0");
        }

        var operators = new List<string>() { "^", "/", "*", "+", "-" };

        foreach (var op in operators) // check each op in order
        {
            bool containsOp = range.Contains(op);
            while (containsOp) //get all the ops before moving on to the next op
            {
                int indexOfOp = range.IndexOf(op);

                double firstNum = double.Parse(range[indexOfOp - 1]);
                double secondNum = GetSecondNum(range, indexOfOp);

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
                int indexOfFirstNum = indexOfOp - 1;
                int indexOfSecondNum = range.IndexOf(Math.Abs(secondNum).ToString(), indexOfFirstNum + 1);
                int distance = indexOfSecondNum - indexOfFirstNum;

                range.RemoveRange(indexOfFirstNum, distance + 1);

                bool negativeNum = result < 0;
                if (negativeNum)
                {
                    if (range.Count() == 0)
                    {
                        range.Insert(indexOfOp - 1, result.ToString());
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

    public static double GetSecondNum(List<string> range, int index)
    {
        bool isNumber = double.TryParse(range[index + 1], out double num);
        if (isNumber)
        {
            return num;
        }
        else
        {
            bool foundNegativeNumber = range[index + 1] == "-";
            if (foundNegativeNumber)
            {
                num = double.Parse(range[index + 2]);
                num = 0 - num;
            }
            return num;
        }
    }
}