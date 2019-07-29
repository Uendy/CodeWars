using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Bob is preparing to pass IQ test.
        //The most frequent task in this test is to find out which one of the given numbers differs from the others.
        //Bob observed that one number usually differs from the others in evenness.
        //Help Bob — to check his answers, he needs a program that among the given numbers finds one that is different in evenness, 
        //return a position of this number.

        //!Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1(not 0)

        //#Examples :
        //IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even
        //IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the

        string numbers = Console.ReadLine();

        var arrayOfNumber = numbers.Split(' ').Select(int.Parse).ToList();

        var listOfEven = arrayOfNumber.Where(x => x % 2 == 0).ToList();
        var listOfOdd = arrayOfNumber.Where(x => x % 2 != 0).ToList();

        if (listOfOdd.Count() == 1)
        {
            int index = arrayOfNumber.IndexOf(listOfOdd[0]) + 1;
            Console.WriteLine(index);
        }
        else // in the even list
        {
            int index = arrayOfNumber.IndexOf(listOfEven[0]) + 1;
            Console.WriteLine(index);
        }

        // Whay I was trying to do
        // even.Count() == 1 ? even.First().Index + 1: odd.First().Index + 1; 

        // Most Clever Solution:
        // var ints = numbers.Split(' ').Select(int.Parse).ToList();
        // var unique = ints.GroupBy(n => n % 2).OrderBy(c => c.Count()).First().First();
        // return ints.FindIndex(c => c == unique) + 1;
    }
}