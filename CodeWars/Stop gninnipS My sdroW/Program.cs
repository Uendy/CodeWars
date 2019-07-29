using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a function that takes in a string of one or more words, and returns the same string,
        //but with all five or more letter words reversed (Just like the name of this Kata). 
        //Strings passed in will consist of only letters and spaces. 
        //Spaces will be included only when more than one word is present.

        //Examples:
        //spinWords("Hey fellow warriors") => returns "Hey wollef sroirraw" 
        //spinWords("This is a test") => returns "This is a test" 
        //spinWords("This is another test")=> returns "This is rehtona test"

        var inputTokens = Console.ReadLine().Split(' ').ToArray();

        for (int index = 0; index < inputTokens.Length; index++)
        {
            string currentWord = inputTokens[index];

            bool fiveOrMore = currentWord.Length >= 5;
            if (fiveOrMore)
            {
                var reversedWord = new string(currentWord.Reverse().ToArray());
                inputTokens[index] = reversedWord;
            }
        }

        string outPut = string.Join(" ", inputTokens);
        Console.WriteLine(outPut);

        //smarter solution:
        //return String.Join(" ", sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
    }
}