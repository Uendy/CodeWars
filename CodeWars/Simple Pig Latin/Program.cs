using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Move the first letter of each word to the end of it, then add "ay" to the end of the word.
        //Leave punctuation marks untouched.

        //Examples:
        //Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
        //Kata.PigIt("Hello world !");     // elloHay orldway !

        var inputTokens = Console.ReadLine().Split(' ').ToArray();

        for (int index = 0; index < inputTokens.Length; index++)
        {
            string currentWord = inputTokens[index];

            bool notAWord = currentWord.Contains("!");
            if (notAWord)
            {
                continue;
            }

            var currentWordAsArray = currentWord.ToCharArray();

            char firstLetter = currentWordAsArray.First();

            string rest = new string(currentWordAsArray.Skip(1).ToArray());

            string suffix = firstLetter + "ay";

            string newWord = string.Concat(rest, suffix);

            inputTokens[index] = newWord;
        }

        string outPut = string.Join(" ", inputTokens);
        Console.WriteLine(outPut);

        // My style solution but cleaner:

        //var words = str.Split(' ');
        //var sb = new StringBuilder();
        //for (int i = 0; i < words.Length; i++)
        //{
        //    sb.Append(words[i].Substring(1));
        //    sb.Append(words[i][0]);
        //    sb.Append("ay ");
        //}
        //
        //return sb.ToString().TrimEnd(' ');

        // Most clever solution:
        //return string.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
    }
}