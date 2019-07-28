using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You have an array of numbers.
        //Your task is to sort ascending odd numbers but even numbers must be on their places.

        //Zero isn't an odd number and you don't need to move it.If you have an empty array, you need to return it.

        //Example
        //sortArray([5, 3, 2, 8, 1, 4]) == [1, 3, 2, 8, 5, 4]

        var array = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var oddNumbers = array.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();

        int oddArrayCounter = 0;

        for (int index = 0; index < array.Length; index++)
        {
            bool odd = array[index] % 2 != 0;
            if (odd)
            {
                array[index] = oddNumbers[oddArrayCounter];
                oddArrayCounter++;
            }
        }

        string outPut = string.Join(", ", array);
        Console.WriteLine(outPut);

        //Better Solution:
        //Queue<int> odds = new Queue<int>(array.Where(e => e % 2 == 1).OrderBy(e => e));
        //return array.Select(e => e % 2 == 1 ? odds.Dequeue() : e).ToArray();
    }
}