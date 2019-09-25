using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Complete the method which returns the number which is most frequent in the given input array.
        //If there is a tie for most frequent number, return the largest number among them.

        //Note: no empty arrays will be given.

        //Examples
        //[12, 10, 8, 12, 7, 6, 4, 10, 12]-- > 12
        //[12, 10, 8, 12, 7, 6, 4, 10, 12, 10]-- > 12
        //[12, 10, 8, 8, 3, 3, 3, 3, 2, 4, 10, 12, 10]-- > 3

        int[] arr = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int highertRank = FindMode(arr);

        Console.WriteLine(highertRank);
    }

    public static int FindMode(int[] arr)
    {
        var numAndFrequency = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            bool newNum = !numAndFrequency.ContainsKey(num);
            if (newNum)
            {
                numAndFrequency[num] = 0;
            }

            numAndFrequency[num]++;
        }

        var result = numAndFrequency.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

        var highestRank = result.Keys.First();

        return highestRank;

        //other solution:
        //return arr
        //  .GroupBy(i => i)
        //  .OrderByDescending(gr => gr.Count())
        //  .ThenByDescending(gr => gr.Key)
        //  .Select(gr => gr.Key)
        //  .First();
    }
}