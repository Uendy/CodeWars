using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
public class Program
{
    public static void Main()
    {
        //Kata: https://www.codewars.com/kata/last-digit-of-a-huge-number/train/csharp

        //For a given list [x1, x2, x3, ..., xn] compute the last (decimal) digit of x1 ^ (x2 ^ (x3 ^ (... ^ xn))).

        //Ex:
        //int[] array = new int[] { 3, 4, 2 };
        //LastDigit(array) == 1
        //because 3 ^ (4 ^ 2) = 3 ^ 16 = 43046721.

        //Beware: powers grow incredibly fast. For example, 9 ^ (9 ^ 9) has more than 369 millions of digits.
        //lastDigit has to deal with such numbers efficiently.

        //Corner cases: we assume that 0 ^ 0 = 1 and that lastDigit of an empty list equals to 1.


        //What if I try with sb?
        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToList();

        var bigNumber = new BigInteger();

        while (input.Count() != 1)
        {
            bigNumber = PowerByList(bigNumber, input);
            input.Remove(input.Count() - 1);
            input.Remove(input.Count() - 2);

            input.Add(bigNumber);
        }

        int lastDigit = int.Parse(input[0].ToString().ToCharArray().Last().ToString());
        Console.WriteLine(lastDigit);
    }

    public static BigInteger PowerByList(BigInteger bigNumber, List<BigInteger> input) // do this with recursion
    {
        BigInteger lastNum = input[input.Count - 1];
        BigInteger secondLast = input[input.Count - 2];


        bigNumber = Math.Pow(secondLast, lastNum);

        return bigNumber;
    }
}