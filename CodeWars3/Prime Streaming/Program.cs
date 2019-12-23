using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //https://www.codewars.com/kata/prime-streaming-pg-13/train/csharp

        //Create an endless stream of prime numbers - a bit like IntStream.of(2, 3, 5, 7, 11, 13, 17), but infinite. 
        //The stream must be able to produce a million primes in a few seconds.

        //input1 = start from
        //input2 = number of primes wanted

        //ex
        // 0, 10
        // 2, 3, 5, 7, 11, 13, 17, 19, 23, 29

        int startNum = int.Parse(Console.ReadLine());
        if (startNum < 2) // two is the smallest non-negative prime number 
        {
            startNum = 2; 
        }
        int primesNeeded = int.Parse(Console.ReadLine());

        var primes = new List<long>();

        for (int index = startNum; primes.Count() != primesNeeded; index++)
        {
            bool isPrime = CheckPrime(index);
            if (isPrime)
            {
                primes.Add(index);
            }
        }

        var outPut = string.Join(", ", primes);
        Console.WriteLine(outPut);

    }

    public static bool CheckPrime(int index)
    {
        bool isPrime = true;
        for (int i = 2; i <= Math.Sqrt(index); i++)
        {
            if (index % i == 0)
            {
                isPrime = false;
            }
        }

        return isPrime;
    }
}