using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet.
        //ROT13 is an example of the Caesar cipher.

        //Create a function that takes a string and returns the string ciphered with Rot13. 
        //If there are numbers or special characters included in the string, they should be returned as they are.
        //Only letters from the latin/ english alphabet should be shifted, like in the original Rot13 "implementation".

        string message = Console.ReadLine();

        var asArray = message.ToCharArray();

        for (int index = 0; index < asArray.Count(); index++)
        {
            int currentLetter = asArray[index];

            bool isLetter = char.IsLetter(asArray[index]);
            if (isLetter)
            {

                currentLetter += 13;

                bool mustSubtract = (currentLetter > 90 && currentLetter < 104) || currentLetter > 122; // cant be in those ranges
                if (mustSubtract)
                {
                    currentLetter -= 26;
                }

                asArray[index] = (char)currentLetter;
            }
        }

        var outPut = string.Join("", asArray);
        Console.WriteLine(outPut);

        //Clever:
        //string result = "";
        //foreach (var s in message)
        //{
        //    if ((s >= 'a' && s <= 'm') || (s >= 'A' && s <= 'M'))
        //        result += Convert.ToChar((s + 13)).ToString();
        //    else if ((s >= 'n' && s <= 'z') || (s >= 'N' && s <= 'Z'))
        //        result += Convert.ToChar((s - 13)).ToString();
        //    else result += s;
        //}
        //return result;
    }
}