using System;
public class Program
{
    public static void Main()
    {
        //Write a function named first_non_repeating_letter that takes a string input, and returns the first character that is not repeated anywhere in the string.

        //For example, if given the input 'stress', the function should return 't', since the letter t only occurs once in the string, and occurs first in the string.

        //As an added challenge, upper-and lowercase letters are considered the same character,
        //but the function should return the correct case for the initial letter.For example, the input 'sTreSS' should return 'T'.

        //If a string contains all repeating characters, it should return an empty string("") or None --see sample tests.

        string s = Console.ReadLine();

        if (s == string.Empty)
        {
            Console.WriteLine(s);
            Environment.Exit(0);
        }

        var asCharArray = s.ToCharArray();

        for (int index = 0; index < asCharArray.Length; index++)
        {
            char currentChar = asCharArray[index];

            int firstIndexLower = s.ToLower().IndexOf(currentChar);
            int firstIndexUpper = s.ToUpper().IndexOf(currentChar);
             
            //need to check for both or moonmen will not pass as the 2nd o's index matches lastIndexLower.

            int lastIndexUpper = s.ToUpper().LastIndexOf(currentChar);
            int lastIndexLower = s.ToLower().LastIndexOf(currentChar);

            bool isAlone = index == lastIndexLower && index == firstIndexLower|| index == lastIndexUpper && index == firstIndexUpper;
            if (isAlone)
            {
                Console.WriteLine(currentChar);
                Environment.Exit(0);
            }
        }

        // clever solution:
        // var ret = s.GroupBy(z => char.ToLower(z)).Where(g => g.Count() == 1).FirstOrDefault();
        //return (ret != null) ? ret.First().ToString() : string.Empty;
    }
}