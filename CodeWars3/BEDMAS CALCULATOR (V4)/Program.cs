using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<string> formatedInput = FormatInput(input);
    }
    public static string FormatInput(string input)
    {
        var list = new List<string>();
        var operators = new List<string>() { "+", "-", "*", "/", "^"};
        var inputArray = input.ToCharArray();

        var sb = new StringBuilder();
        bool openBracket = false;

        for (int index = 0; index < inputArray.Count(); index++)
        {
            var currentChar = inputArray[index].ToString();

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
                bool lastIndex = index == inputArray.Count() - 1;
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
}