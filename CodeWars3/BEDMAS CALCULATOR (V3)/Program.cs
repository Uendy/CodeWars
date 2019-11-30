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
        var list = GetElements(input);
        list = ExpandBrackets(list);


        //var result = ApplyCalculator(list);
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

        //find the innerMost Brackets and start from there

        while (startBrackets.Count() != 0)
        {

            int shortestDistance = int.MaxValue;
            int indexToStart = 0;

            foreach (var startIndex in startBrackets)
            {
                foreach (var endIndex in endBrackets)
                {
                    int distance = endIndex - startIndex;
                    bool newShorterDistance = shortestDistance > distance;
                    {
                        shortestDistance = distance;
                        indexOfStart = startIndex;
                    }
                }
            }

            var range = list.GetRange(indexOfStart + 1, shortestDistance-1);
            var result = EDMAS(range);

            //remove the past range with the result
            list.RemoveRange(indexOfStart, shortestDistance);
            list.Insert(indexOfStart, result.ToString());
        }

        return list;
    }


    //public static double ApplyCalculator(List<string> list)
    //{

    //}
    public static double EDMAS(List<string> range)
    {
        //so as to keep any leading minuses in tact
        range.Insert(0, "+"); 
        range.Insert(0, "0");

        var operators = new List<string>() { "^", "/", "*", "-", "+" };

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

                //if the second is negative, must all remove the minus between the op and num2
                bool secondNumNegative = 0 > secondNum;
                if (secondNumNegative)
                {
                    range.RemoveAt(indexOfOp + 1);
                }
                range.RemoveAt(indexOfOp + 1);
                range.RemoveAt(indexOfOp);
                range.RemoveAt(indexOfOp - 1);

                range.Insert(indexOfOp - 1, result.ToString()); // inserting the result number in place of the range

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