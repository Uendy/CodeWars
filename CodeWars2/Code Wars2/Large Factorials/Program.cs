using System;
public class Program
{
    public static void Main()
    {
        //In mathematics, the factorial of integer n is written as n!. 
        //It is equal to the product of n and every integer preceding it. 
        //For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

        //Your mission is simple: write a function that takes an integer n and returns the value of n!.

        //You are guaranteed an integer argument. 
        //For any values outside the non-negative range, return null, nil or None(return an empty string "" in C and C++). 
        //For non-negative numbers a full length number is expected for example, return 25! = "15511210043330985984000000" as a string.

        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("null");
        }

        int[] res = new int[500];
        res[0] = 1;
        int resultSize = 1;

        for (int x = 2; x <= n; x++)
            resultSize = multiply(x, res, resultSize);

        for (int i = resultSize - 1; i >= 0; i--)
            Console.Write(res[i].ToString());
    }

    static int multiply(int x, int[] res, int resultSize)
    {
        int carry = 0; 
        for (int i = 0; i < resultSize; i++)
        {
            int prod = res[i] * x + carry;
            res[i] = prod % 10; 
            carry = prod / 10;
        }

        while (carry != 0)
        {
            res[resultSize] = carry % 10;
            carry = carry / 10;
            resultSize++;
        }
        return resultSize;
    }

    //double factorial = 1;

    //for (int i = n; i >= 2; i--)
    //{
    //    factorial *= i;
    //}

    //var output = factorial.ToString();
    //var outputLength = output.Length;
    //output = factorial.ToString(new string('#', outputLength));
    //Console.WriteLine(output);
}
