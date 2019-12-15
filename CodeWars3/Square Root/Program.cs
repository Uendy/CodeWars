using System;
public class Program
{
    public static void Main()
    {
        double input = double.Parse(Console.ReadLine());
        bool isNegative = input < 0;
        input = Math.Abs(input);

        double startNum = 0;
        double range = 1;
        

        double root = FindSquareRoot(input, startNum, range);

        if (isNegative)
        {
            Console.Write("-");
        }
        Console.WriteLine(root);
    }

    public static double FindSquareRoot(double input, double startNum, double range)
    {
        // nestd for cycles where we do [index ^ (power of ) index]
        // until we get to a the input num or a num higher than input num
        // if higher()
        // go between the last num smaller than input and bigger than input and cycle through with 0.1 bigger precision
        // since nested it will do this 10 times before it stops and returns the closest answer
        // as some nums dont have a perfect square

        for (double num = startNum; ; num += range)
        {
            double currentNum = Math.Pow(num, 2);

            bool foundRoot = currentNum == input;
            if (foundRoot)
            {
                return num;
            }

            bool overShot = currentNum > input;
            if (overShot)
            {
                range /= 10;
                double lastOkayNumber = currentNum - range;
                FindSquareRoot(input, lastOkayNumber, range);
            }
        }
    }
}