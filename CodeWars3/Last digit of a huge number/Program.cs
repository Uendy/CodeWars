using System;
using System.Linq;
using System.Numerics;
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


        var array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        BigInteger t = 1;
        var arr = array.Reverse().ToList();

        foreach (var x in arr)
        {
            if (t < 4)
                t = BigInteger.Pow(x, int.Parse(t.ToString()));
            else
            {
                int exponent = int.Parse(BigInteger.ModPow(t, 1, 4).ToString()) + 4;
                t = BigInteger.Pow(x, exponent);
            }
        }

        Console.WriteLine((int)BigInteger.ModPow(t, 1, 10));
    }
}