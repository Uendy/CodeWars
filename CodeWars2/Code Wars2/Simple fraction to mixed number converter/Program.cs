using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        #region;
        //Given a string representing a simple fraction x/y, 
        //your function must return a string representing the corresponding mixed fraction in the following format:
        //[sign] a b/c

        // where a is integer part and b/c is irreducible proper fraction.There must be exactly one space between a and b/c.
        //Provide[sign] only if negative(and non zero) and
        //only at the beginning of the number(both integer part and fractional part must be provided absolute).

        //If the x/y equals the integer part, return integer part only.If integer part is zero, return the irreducible proper fraction only.
        //In both of these cases, the resulting string must not contain any spaces.

        //Division by zero should raise an error (preferably, the standard zero division error of your language).
        //Value ranges
        //-10 000 000 < x< 10 000 000
        //-10 000 000 < y< 10 000 000
        //Examples
        //Input: 42/9, expected result: 4 2/3.
        //Input: 6/3, expedted result: 2.
        //Input: 4/6, expected result: 2/3.
        //Input: 0/18891, expected result: 0.
        //Input: -10/7, expected result: -1 3/7.
        //Inputs 0/0 or 3/0 must raise a zero division error.
        //Note: Make sure not to modify the input of your function in-place, it is a bad practice.
        #endregion

        string input = Console.ReadLine();

        var numbers = input.Split('/').Select(int.Parse).ToArray();

        int numerator = numbers[0];
        int denomenator = numbers[1];

        bool dividingByZero = denomenator == 0;
        if(dividingByZero)
        {
            throw new DivideByZeroException();
        }

        bool numeratorIsZero = numerator == 0;
        if (numeratorIsZero)
        {
            Console.WriteLine("0");
            Environment.Exit(0);
        }

        //// but what if it can be shortened more than once? ex: 42/14 -> 6/2 -> 1/3 //// so i made keep going to cycle it atleast twice
        bool keepGoing = true;
        int round = 0;
        while (keepGoing)
        {
            bool negativeDenom = denomenator < 0;
            if (negativeDenom)
            {
                for (int LCD = denomenator; LCD < 0; LCD++) //LCD = Lowest Common Denomenator
                {
                    bool foundLCD = numerator % LCD == 0 && denomenator % LCD == 0;
                    if (foundLCD)
                    {
                        numerator /= LCD;
                        denomenator /= LCD;
                        round = 0;
                        break;
                    }
                }
            }
            else // denominator is positive so a reverse loop is used
            {
                for (int LCD = denomenator; LCD > 1; LCD--) //LCD = Lowest Common Denomenator
                {
                    bool foundLCD = numerator % LCD == 0 && denomenator % LCD == 0;
                    if (foundLCD)
                    {
                        numerator /= LCD;
                        denomenator /= LCD;
                        round = 0;
                        break;
                    }
                }
            }
            round++;

            if (round == 2)
            {
                keepGoing = false;
            }
        }

        int wholeNumber = numerator / denomenator; 
        int remainder = numerator % denomenator;

        // formating and printing         
        var listOfoutput = new List<string>();

        if (wholeNumber != 0)
        {
            listOfoutput.Add(wholeNumber.ToString());
        }

        if (listOfoutput.Count() == 0) // if no whole number
        {
            listOfoutput.Add($"{remainder.ToString()}/{denomenator.ToString()}");
        }
        else if(listOfoutput.Count() != 0 && remainder != 0) // if there is a whole number & a remainder (+ make remainder positive)
        {
            listOfoutput.Add($"{Math.Abs(remainder).ToString()}/{Math.Abs(denomenator).ToString()}");
        }

        var output = string.Join(" ", listOfoutput).Trim();

        Console.WriteLine(output);
    }
}