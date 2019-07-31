using System;
using System.Collections.Generic;
using System.Linq;
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

        var asArray = s.ToCharArray().ToList();

        var charAndCount = new Dictionary<char, int>();

        foreach (var charecter in asArray)
        {
            // to find if the key is there already and if there is one of it already that is  upper or lower case
            bool alreadyExists = charAndCount.ContainsKey(charecter)  
                || charAndCount.ContainsKey((char)(charecter - ' '))
                || charAndCount.ContainsKey((char)(charecter + ' '));

            if (alreadyExists)
            {
                // TODO: cant find the key if its a upper or lower case
                try
                {
                    charAndCount[charecter]++;
                }
                catch (Exception)
                {
                    try
                    {
                        charAndCount[(char)(charecter - ' ')]++;
                    }
                    catch (Exception)
                    {
                        charAndCount[(char)(charecter + ' ')]++;
                    }
                }
            }
            else // new char
            {
                charAndCount[charecter] = 1;
            }
        }

        bool allRepeatingChars = !charAndCount.Values.Any(x => x == 1);
        if (allRepeatingChars)
        {
            Console.WriteLine(string.Empty);
            Environment.Exit(0);
        }

        char firstNotRepeatingChar = ' ';

        foreach (var key in charAndCount.Keys)
        {
            bool isNonRepeating = charAndCount[key] == 1;
            if (isNonRepeating)
            {
                firstNotRepeatingChar = key;
                Console.WriteLine(firstNotRepeatingChar);
                Environment.Exit(0);
            }
        }

        Environment.Exit(0);

        //clever solution:
        //var ret = s.GroupBy(z => char.ToLower(z)).Where(g => g.Count() == 1).FirstOrDefault();
        //return (ret != null) ? ret.First().ToString() : string.Empty;
    }
}