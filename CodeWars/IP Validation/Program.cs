using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write an algorithm that will identify valid IPv4 addresses in dot-decimal format. 
        //IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.
        //Input to the function is guaranteed to be a single string.

        //Examples

        //Valid inputs:
        //1.2.3.4
        //123.45.67.89

        //Invalid inputs:
        //1.2.3
        //1.2.3.4.5
        //123.456.78.90
        //123.045.067.089
        //Note that leading zeros(e.g. 01.02.03.04) are considered invalid.

        string ipAddres = Console.ReadLine();

        bool isValid = true;

        if (ipAddres == string.Empty)
        {
            isValid = false;
            Console.WriteLine(isValid);
            Environment.Exit(0);
        }

        var tokens = ipAddres.Split('.').ToArray();

        bool notEnoughOctets = tokens.Count() != 4;
        if (notEnoughOctets)
        {
            isValid = false;
        }

        foreach (var segment in tokens)
        {
            var segmentArray = segment.ToCharArray().ToList();

            bool leadingZero = segmentArray.First() == '0' && segment.Length == 3;
            if (leadingZero)
            {
                isValid = false;
            }

            bool isNumber = int.TryParse(segment, out int asNumber);
            if (!isNumber)
            {
                isValid = false;
                Console.WriteLine(isValid);
                Environment.Exit(0);
            }

            bool invalidNumber = asNumber < 0 || asNumber > 255;
            if (invalidNumber)
            {
                isValid = false;
            }
        }

        Console.WriteLine(isValid);

        //Regex Solution:
        //var octet = "([1-9][0-9]{0,2})";
        //var reg = $@"{octet}\.{octet}\.{octet}\.{octet}";
        //return new Regex(reg).IsMatch(IpAddres);
    }
}