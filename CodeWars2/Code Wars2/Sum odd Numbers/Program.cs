using System;
public class Program
{
    public static void Main()
    {
        //Given the triangle of consecutive odd numbers:

        //             1
        //          3     5
        //       7     9    11
        //   13    15    17    19
        //21    23    25    27    29...
        //Calculate the row sums of this triangle from the row index(starting at index 1) 

        //Examples:
        //rowSumOddNumbers(1); // 1
        //rowSumOddNumbers(2); // 3 + 5 = 8

        long n = long.Parse(Console.ReadLine());

        long total = SumOddNums(n);

        Console.WriteLine(total);
    }

    public static long SumOddNums(long n)
    {
        long number = 1;
        long total = 0;
        for (long currentRow = 1; currentRow <= n; currentRow++)
        {
            for (long i = 0; i < currentRow; i++)
            {
                if (currentRow == n)
                {
                    total += number;
                }
                number += 2;
            }
        }

        return total;
    }
}