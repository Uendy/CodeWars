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

        var result = ApplyCalculator(list);
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
    public static double ApplyCalculator(List<string> list)
    {
        
    }
}