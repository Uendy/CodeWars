using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //In this simple Kata your task is to create a function that turns a string into a Mexican Wave. 
        //You will be passed a string and you must return that string in an array where an uppercase letter is a person standing up.

        //Rules
        //1.The input string will always be lower case but maybe empty.
        //2.If the character in the string is whitespace then pass over it as if it was an empty seat.

        //Example
        //wave("hello") => [] string{"Hello", "hEllo", "heLlo", "helLo", "hellO"}

        string str = Console.ReadLine();

        var wave = MexicanWaveTheString(str);

        string outPut = string.Join(", ", wave);
        Console.WriteLine(outPut);
    }

    public static List<string> MexicanWaveTheString(string str)
    {
        var wave = new List<string>();

        var stringAsArray = str.ToCharArray();
        for (int index = 0; index < str.Length; index++)
        {
            if (stringAsArray[index] == ' ')
            {
                continue;
            }

            string capitalizedWave = string.Empty;
            string beforeCapital = str.Substring(0, index);
            string capital = stringAsArray[index].ToString().ToUpper();
            string afterCapital = str.Substring(index + 1);

            capitalizedWave = string.Concat(beforeCapital, capital, afterCapital);

            wave.Add(capitalizedWave);
        }

        return wave;
    }
}