using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Define a function that takes an integer argument and returns logical value true
        //or false depending on if the integer is a prime

        bool isPrime = true;

        int number = int.Parse(Console.ReadLine());

        if (number <= 1)
        {
            Console.WriteLine(isPrime = false);
            Environment.Exit(0);
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
            }
        }

        Console.WriteLine(isPrime);
    }
}