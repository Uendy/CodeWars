using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}