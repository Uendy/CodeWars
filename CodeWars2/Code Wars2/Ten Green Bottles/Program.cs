using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
        //Write some amazing code to reproduce the above lyrics starting from n green bottles!

        //parameter n is 1 to 10
        //newline terminates every line(including the last)
        //don't forget the blank lines between the verses

        int n = int.Parse(Console.ReadLine());

        string outPut = Print(n);
        Console.WriteLine(outPut);
    }

    public static string Print(int n)
    {
        var d = new[] { "no", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        var lyrics = "";
        for (var i = n - 1; i >= 0; i--)
        {
            var s = i >= 1 ? "s" : "";
            var lasts = i == 1 ? "" : "s";
            var lastn = i == 0 ? "" : "\n";
            var text = i >= 1 ? "And if one" : "If that one";
            lyrics += CultureInfo.InvariantCulture.TextInfo.ToTitleCase(d[i + 1]) + " green bottle" + s + " hanging on the wall,\n" +
                      CultureInfo.InvariantCulture.TextInfo.ToTitleCase(d[i + 1]) + " green bottle" + s + " hanging on the wall,\n" +
                      text + " green bottle should accidentally fall,\n" +
                      "There'll be " + d[i] + " green bottle" + lasts + " hanging on the wall.\n" + lastn;
        }
        return lyrics;
    }
}