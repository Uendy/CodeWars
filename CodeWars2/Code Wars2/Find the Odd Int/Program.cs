using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int[] seq = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        int oddNum = FindOddOccuranceInt(seq);

        Console.WriteLine(oddNum);
    }

    public static int FindOddOccuranceInt(int[] seq)
    {
        return seq.ToList()
                  .GroupBy(x => x) //Group by each element in the array
                  .Where(x => (x.Count() % 2) != 0) //Find grouped odd numbers
                  .Select(x => x.First())
                  .FirstOrDefault(); //since array will only contain 1 odd number, get first one
    }
}