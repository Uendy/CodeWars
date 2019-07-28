using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //Check to see if a string has the same amount of 'x's and 'o's. 
        //The method must return a boolean and be case insensitive. 
        //The string can contain any char.

        //Examples input/ output:
        //XO("ooxx") => true
        //XO("xooxx") => false
        //XO("ooxXm") => true
        //XO("zpzpzpp") => true // when no 'x' and 'o' is present should return true
        //XO("zzoo") => false
        #endregion

        string input = Console.ReadLine().ToLower();

        var oS = input.ToCharArray().Where(x => x == 'o').ToArray();
        var xS = input.ToCharArray().Where(x => x == 'x').ToArray();

        Console.WriteLine(oS.Count() == xS.Count());

        //Clever Solution:
        //return input.ToLower().Count(i => i == 'x') == input.ToLower().Count(i => i == 'o');
    }
}