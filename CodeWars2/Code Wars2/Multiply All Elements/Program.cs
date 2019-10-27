using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //This function must return another function, which takes a single integer as an argument and returns a new array.
        //The returned array should consist of each of the elements from the first array multiplied by the integer.

        int[] array = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int multiplyBy = int.Parse(Console.ReadLine());

        if (array.Count() == 0)
        {
            Console.WriteLine("input is an empty array");
        }
        else
        {
            var multipliedArray = MultiplyArray(array, multiplyBy);

            string outPut = string.Join(", ", multipliedArray);
            Console.WriteLine(outPut);
        }
    }

    public static int[] MultiplyArray(int[] array, int multiplyBy)
    {
        var updatedArray = array.Select(x => x * multiplyBy).ToArray();

        return updatedArray;
    }
}