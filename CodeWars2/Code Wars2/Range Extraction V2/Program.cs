using System;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        //the kata is on the first Range Extraction

        string input = Console.ReadLine();
        var args = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var solution = TruncateRange(args);

        Console.WriteLine(solution);
    }

    public static string TruncateRange(int[] args)
    {
        var sb = new StringBuilder();
        for (int index = 0; index < args.Length; index++)
        {
            var startAt = args[index];
            while (index + 1 < args.Length && args[index + 1] - args[index] == 1) ++index;
            var endAt = args[index];

            if (endAt == startAt)
            {
                sb.Append($"{startAt},");
            }
            else if (endAt - startAt == 1)
            {
                sb.Append($"{startAt},{endAt},");
            }
            else
            {
                sb.Append($"{startAt}-{endAt},");
            }
        }
        return sb.ToString().TrimEnd(',');
    }
}