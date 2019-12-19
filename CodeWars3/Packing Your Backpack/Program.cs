using System;
using System.Collections.Generic;
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

        var luggage = new Dictionary<int, int>();
        for (int index = 0; index < scores.Length; index++)
        {
            luggage[scores[index]] = weights[index];
        }

        luggage = luggage.OrderBy(x => x.Key).ThenBy(x => x.Value < capacity).ToDictionary(x => x.Key, y => y.Value);

        var indexOfItems = new List<int>();
        foreach (var key in luggage.Keys)
        {

        }
        string outPut = string.Join(", ", indexOfItems);
        Console.WriteLine(outPut);
    }
}