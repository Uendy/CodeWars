using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a function that accepts an array of 10 integers (between 0 and 9),
        //that returns a string of those numbers in the form of a phone number.

        //Example: Kata.CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })  => returns "(123) 456-7890"

        var numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        var start = numbers.Take(3).ToArray();
        var middle = numbers.Skip(3).ToArray().Take(3).ToArray();
        var end = numbers.Reverse().ToArray().Take(4).Reverse().ToArray();

        string startOutPut = string.Join("", start);
        string middleOutPut = string.Join("", middle);
        string endOutPut = string.Join("", end);

        Console.WriteLine($"({startOutPut}) {middleOutPut}-{endOutPut}");

        //My method but smarter:
        // string.Format(
        // "({0}) {1}-{2}",
        // string.Join("", numbers.Take(3)),
        // string.Join("", numbers.Skip(3).Take(3)),
        // string.Join("", numbers.Skip(6));

        //better solutions:
        //long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");

        // or: "(" + n[0] + n[1] + n[2] + ") " + n[3] + n[4] + n[5] + "-" + n[6] + n[7] + n[8] + n[9];
    }
}