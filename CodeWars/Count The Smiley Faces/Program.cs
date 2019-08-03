using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Given an array (arr) as an argument complete the function countSmileys that should return the total number of smiling faces.
        //Rules for a smiling face:
        //-Each smiley face must contain a valid pair of eyes.Eyes can be marked as : or ;
        //-A smiley face can have a nose but it does not have to. Valid characters for a nose are - or ~
        //-Every smiling face must have a smiling mouth that should be marked with either) or D.
        //No additional characters are allowed except for those mentioned.

        //Valid smiley face examples:
        //:) :D; -D :~)
        //Invalid smiley faces:
        //; ( :> :} :] 

        //Example cases:
        //countSmileys([':)', ';(', ';}', ':-D']);       // should return 2;
        //countSmileys([';D', ':-(', ':-)', ';~)']);     // should return 3;
        //countSmileys([';]', ':[', ';*', ':$', ';-D']); // should return 1;

        //Note: In case of an empty array return 0. You will not be tested with invalid input(input will always be an array).
        //Order of the face(eyes, nose, mouth) elements will always be the same

        var smileys = Console.ReadLine().Trim().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var eyes = new char[] { ':', ';' };
        var nose = new char[] { '-', '~' };
        var mouth = new char[] { ')', 'D' };

        int countOfSmileys = 0;

        foreach (var face in smileys)
        {
            var faceAsArray = face.ToCharArray();

            bool isSmile = false;

            if (faceAsArray.Count() == 2)
            {
                isSmile = eyes.Contains(faceAsArray.First()) && mouth.Contains(faceAsArray.Last());
            }
            else if (faceAsArray.Count() == 3)
            {
                isSmile = eyes.Contains(faceAsArray.First()) && nose.Contains(faceAsArray[1]) && mouth.Contains(faceAsArray.Last());
            }

            if (isSmile == true)
            {
                countOfSmileys++;
            }
        }

        Console.WriteLine(countOfSmileys);

        //Regex Solution:
        // return smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));

        //Clever Solution:
        //int count = 0;
        //foreach (string smiley in smileys)
        //{
        //    if (((smiley.Contains(':') || smiley.Contains(';'))) && ((smiley.Contains(')') || smiley.Contains('D'))) && !smiley.Contains(' '))
        //        count++;
        //}

    }
}