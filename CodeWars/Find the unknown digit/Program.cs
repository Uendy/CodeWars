using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        #region
        //You are helping an archaeologist decipher some runes.
        //He knows that this ancient society used a Base 10 system, and that they never start a number with a leading zero. 
        //He's figured out most of the digits as well as a few operators, but he needs your help to figure out the rest.

        //The professor will give you a simple math expression, of the form:
        //[number][op][number] =[number]

        //He has converted all of the runes he knows into digits.
        //The only operators he knows are addition(+),subtraction(-), and multiplication(*),
        //so those are the only ones that will appear.
        //Each number will be in the range from - 1000000 to 1000000, and will consist of only the digits 0 - 9, possibly a leading -,
        //and maybe a few ?s.
        //If there are? s in an expression, they represent a digit rune that the professor doesn't know
        //(never an operator, and never a leading -).
        //All of the ?s in an expression will represent the same digit (0-9), and it won't be one of the other given digits in the expression.
        //No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.

        //Given an expression, figure out the value of the rune represented by the question mark. 
        //If more than one digit works, give the lowest one.
        //If no digit works, well, that's bad news for the professor - it means that he's got some of his runes wrong.
        //output - 1 in that case.

        //Complete the method to solve the expression to find the value of the unknown rune.
        //The method takes a string as a paramater repressenting the expression and will return an int value representing the unknown rune
        //or - 1 if no such rune exists.

        //Example: 123 * 45 ?= 5 ? 088 // ==> 6 = ?
        #endregion

        string expression = Console.ReadLine();

        var digits = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        var expTokens = expression.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var result = expTokens[1];

        var resultAsArray = result.ToCharArray();
        foreach (var digit in resultAsArray)
        {
            bool alreadyDeciphered = digits.Contains(digit);
            digits.Remove(digit);
        }

        string firstNum = string.Empty;
        string secondNum = string.Empty;

        var firstPart = expTokens[0];

        if (firstPart.Contains("*"))
        {
            var firstPartTokens = expTokens[0].Split('*').ToArray();
            firstNum = firstPartTokens[0];
            secondNum = firstPartTokens[1];
        }
        else if (firstPart.Contains("+"))
        {
            var firstPartTokens = expTokens[0].Split('+').ToArray();
            firstNum = firstPartTokens[0];
            secondNum = firstPartTokens[1];
        }
        else if (firstPart.Contains("-"))
        {
            for (int index = 1; index < firstPart.Count(); index++)
            {
                bool isMinus = firstPart[index] == '-';
                if (isMinus)
                {
                    firstNum = expTokens[0].Substring(0, index);
                    secondNum = expTokens[0].Substring(index + 1);
                    break;
                }
            }
        }

        var firstNumAsArray = firstNum.ToCharArray();
        foreach (var digit in firstNumAsArray)
        {
            bool alreadyDeciphered = digits.Contains(digit);
            digits.Remove(digit);
        }

        var secondNumAsArray = secondNum.ToCharArray();
        foreach (var digit in secondNumAsArray)
        {
            bool alreadyDeciphered = digits.Contains(digit);
            digits.Remove(digit);
        }


        //Finding the components
        char op = '-'; // since '-' is hardest to check for as a number could be negative

        bool addition = expression.Contains('+');
        if (addition)
        {
            op = '+';
        }
        else
        {
            bool multiplication = expression.Contains('*');
            if (multiplication)
            {
                op = '*';
            }
        }

        //run a for cylce to determine which number could go in there and if you get to 10 then return -1;
        for (int index = 0; index < digits.Count(); index++)
        {
            var currentDigit = int.Parse(digits[index].ToString());

            char missingX = (char)(currentDigit + 48);

            var currentFirst = int.Parse(firstNum.Replace('?', missingX));
            var currentSecond = int.Parse(secondNum.Replace('?', missingX));
            var currentResult = int.Parse(result.Replace('?', missingX));
          

            bool correctNumber = false;
            switch (op)
            {
                case '+':
                    if (currentFirst + currentSecond == currentResult)
                    {
                        correctNumber = true;
                    }
                    break;

                case '-':
                    if (currentFirst - currentSecond == currentResult)
                    {
                        correctNumber = true;
                    }
                    break;

                case '*':
                    if (currentFirst * currentSecond == currentResult)
                    {
                        correctNumber = true;
                    }
                    break;
            }

            if (correctNumber == true)
            {
                Console.WriteLine($"{currentFirst} {op} {currentSecond} = {currentResult}");
                Environment.Exit(0);
            }
        }
        Console.WriteLine(-1);
    }
}