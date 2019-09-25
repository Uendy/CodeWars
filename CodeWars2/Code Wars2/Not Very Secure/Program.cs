using System;
public class Program
{
    public static void Main()
    {
        //In this example you have to validate if a user input string is alphanumeric. The given string is not nil/null/NULL/None, so you don't have to check that.

        //The string has the following conditions to be alphanumeric:

        //At least one character("" is not valid)
        //Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
        //No whitespaces / underscore

        string input = Console.ReadLine();

        bool isSecure = CheckSecurity(input);

        Console.WriteLine(isSecure);

        //Other solutions:

        //if (str.Length == 0) return false;
        //string s = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //return !str.Any(c => !s.Contains(c));

        //new Regex("^[a-zA-Z0-9]+$").Match(str).Success;
    }

    public static bool CheckSecurity(string str)
    {
        bool lengthAboveZero = str.Length >= 1; //At least one character("" is not valid)
        if (!lengthAboveZero)
        {
            return false;
        }

        var asArray = str.ToCharArray();
        bool onlyLettersAndDigits = true;
        foreach (var character in asArray)
        {
            if (!char.IsLetterOrDigit(character)) //Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
            {
                onlyLettersAndDigits = false;
            }
        }

        if (onlyLettersAndDigits == false)
        {
            return false;
        }

        bool containsSpaceOrUnderscore = str.Contains(" ") || str.Contains("_"); //No whitespaces / underscore
        if (containsSpaceOrUnderscore)
        {
            return false;
        }
        return true;
    }
}