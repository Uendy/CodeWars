using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Kata: https://www.codewars.com/kata/packing-your-backpack/train/csharp

        //You're about to go on a trip around the world! On this trip you're bringing your trusted backpack, that anything fits into.
        //The bad news is that the airline has informed you, that your luggage cannot exceed a certain amount of weight.

        //To make sure you're bringing your most valuable items on this journey you've decided to give all your items a score,
        //that represents how valuable this item is to you.
        //It's your job to pack you bag so that you get the most value out of the items that you decide to bring.

        //Your input will consist of two arrays, one for the scores and one for the weights. 
        //You input will always be valid lists of equal length, so you don't have to worry about verifying your input.

        //You'll also be given a maximum weight. This is the weight that your backpack cannot exceed.

        //Ex:
        //scores = [15, 10, 9, 5]
        //weights = [1, 5, 3, 4]
        //capacity = 8
        //The maximum score will be 29.This number comes from bringing items 1, 3 and 4.

        //Note: Your solution will have to be efficient as the running time of your algorithm will be put to a test.

        var scores = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var weights = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int capacity = int.Parse(Console.ReadLine());

        int n = scores.Length;
        int[,] mat = new int[n + 1, capacity + 1];

        for (int r = 0; r <= capacity; r++)
        {
            mat[0, r] = 0;
        }
        for (int c = 0; c <= n; c++)
        {
            mat[c, 0] = 0;
        }

        for (int item = 1; item <= n; item++)
        {
            for (int cap = 1; cap <= capacity; cap++)
            {
                int maxValWithoutCurr = mat[item - 1, cap];
                int maxValWithCurr = 0;

                int weightOfCurr = weights[item - 1];
                if (cap >= weightOfCurr)
                {
                    maxValWithCurr = scores[item - 1];
                    int remainingCapacity = cap - weightOfCurr;
                    maxValWithCurr += mat[item - 1, remainingCapacity];
                }

                mat[item, cap] = Math.Max(maxValWithoutCurr, maxValWithCurr);
            }
        }

        Console.WriteLine(mat[n, capacity]);
    }
}