using System;
public class Sum
{
    #region
    //Given two integers a and b, which can be positive or negative,
    //find the sum of all the numbers between including them too and return it.
    //If the two numbers are equal return a or b.
    //Note: a and b are not ordered!

    //Examples
    //GetSum(1, 0) == 1   // 1 + 0 = 1
    //GetSum(1, 2) == 3   // 1 + 2 = 3
    //GetSum(0, 1) == 1   // 0 + 1 = 1
    //GetSum(1, 1) == 1   // 1 Since both are same
    //GetSum(-1, 0) == -1 // -1 + 0 = -1
    //GetSum(-1, 2) == 2  // -1 + 0 + 1 + 2 = 2
    #endregion

    public static void Main()
    {
        Console.WriteLine(GetSum(3, 3));
    }

    public static int GetSum(int a, int b)
    {
        int top = Math.Max(a, b);
        int bot = Math.Min(a, b);

        int sum = 0;
        for (int i = bot; i <= top; i++)
        {
            sum += i;
        }
        return sum;
    }
}