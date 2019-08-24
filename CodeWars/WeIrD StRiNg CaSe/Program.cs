using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a function toWeirdCase (weirdcase in Ruby) that accepts a string, 
        //and returns the same string with all even indexed characters in each word upper cased,
        //and all odd indexed characters in each word lower cased. 

        //The indexing just explained is zero based, so the zero-ith index is even, therefore that character should be upper cased.

        //The passed in string will only consist of alphabetical characters and spaces(' ').
        //Spaces will only be present if there are multiple words. Words will be separated by a single space(' ').

        //Examples:
        //toWeirdCase("String");//=> returns "StRiNg"
        //toWeirdCase("Weird string case");//=> returns "WeIrD StRiNg CaSe" //WeIrD StRiNg cAsE

        string s = Console.ReadLine();

        var sAsArray = s.ToCharArray();

        for (int index = 0; index < sAsArray.Length; index++)
        {
            bool even = index % 2 == 0;
            if (even)
            {
                sAsArray[index] = char.ToUpper(sAsArray[index]);
            }
            else // odd
            {
                sAsArray[index] = char.ToLower(sAsArray[index]);
            }
        }

        var output = string.Join("", sAsArray);
        Console.WriteLine(output);

        //return string.Join(" ", 
        //s.Split(' ')
        //.Select(w => string.Concat(
        //  w.Select((ch, i) => i % 2 == 0 ? char.ToUpper(ch) : char.ToLower(ch)
        //))));
    }
}