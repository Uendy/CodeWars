using System;
using System.Linq;
public static class Kata
{
    public static void Main()
    {
        string input = Console.ReadLine();

        var inputTokens = input.Split(' ').ToArray();

        int numberOfWords = inputTokens.Count();

        var outPutArray = new string[numberOfWords + 1];

        foreach (var word in inputTokens)
        {
            var wordAsArray = word.ToCharArray();

            int position = -1;

            foreach (char symbol in wordAsArray)
            {
                bool numberFound = int.TryParse(symbol.ToString(), out position);
                if (numberFound)
                {
                    outPutArray[position] = word;
                    break;
                }
            }
        }

        var outPut = string.Join(" ", outPutArray);
        Console.WriteLine(outPut.TrimStart());
    }
}