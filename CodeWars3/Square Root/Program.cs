using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        double input = double.Parse(Console.ReadLine());

        bool isNegative = input < 0;

        input = Math.Abs(input);

        double startNum = 0;
        double range = 1;
        
        double root = FindSquareRoot(input, isNegative, startNum, range);

        if (isNegative)
        {
            Console.Write("-");
        }
        Console.WriteLine(root);
    }

    public static double FindSquareRoot(double input, bool isNegative, double startNum, double range)
    {
        // nested for cycles where we do [index ^ (power of ) index]
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
                double lastOkayNumber = num - range;
                range /= 10;

                if (double.Parse(range.ToString(), NumberStyles.Any) == 0.00000001) // converts scientific notation to decimal and compares
                {
                    var approximateAnswer = (num + lastOkayNumber) / 2;
                    approximateAnswer = Math.Round(approximateAnswer, 5);
                    Console.Write($"Approximately: ");
                    if (isNegative)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine($"{approximateAnswer}");
                    Environment.Exit(0);
                }

                FindSquareRoot(input, isNegative, lastOkayNumber, range);
            }
        }
    }
}