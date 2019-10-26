using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You are given two numbers a and b where 0 ≤ a ≤ b. 
        //Imagine you construct an array of all the integers from a to b inclusive. 
        //You need to count the number of 1s in the binary representations of all the numbers in the array.

        //Example
        //For a = 2 and b = 7, the output should be 11

        //Given a = 2 and b = 7 the array is: [2, 3, 4, 5, 6, 7]. 
        //Converting the numbers to binary, we get[10, 11, 100, 101, 110, 111], which contains 1 + 2 + 1 + 2 + 2 + 3 = 11 1s.

        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());

        int numberOfOnes = FindBinaryOnesCount(a, b);
        Console.WriteLine(numberOfOnes);
    }

    public static int FindBinaryOnesCount(int a, int b)
    {
        int ones = 0;

        for (int i = a; i <= b; i++)
        {
            string binary = Convert.ToString(i, 2);

            ones += binary.Where(x => x == '1').Count();
        }

        return ones;
    }
}