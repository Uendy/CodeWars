using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        double input = double.Parse(Console.ReadLine());
        bool isNegative = input < 0;
        input = Math.Abs(input);

        double root = FindSquareRoot(input);

        if (isNegative)
        {
            Console.Write("-");
        }
        Console.WriteLine(root);
    }

    public static double FindSquareRoot(double input)
    {
        // nestd for cycles where we do [index ^ (power of ) index]
        // until we get to a the input num or a num higher than input num
        // if higher()
        // go between the last num smaller than input and bigger than input and cycle through with 0.1 bigger precision
        // since nested it will do this 10 times before it stops and returns the closest answer
        // as some nums dont have a perfect square
    }
}