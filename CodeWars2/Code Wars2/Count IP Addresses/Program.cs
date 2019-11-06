using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Implement a function that receives two IPv4 addresses
        //return the number of addresses between them (including the first one, excluding the last one).

        //All inputs will be valid IPv4 addresses in the form of strings. The last address will always be greater than the first one.

        //Examples
        //ips_between("10.0.0.0", "10.0.0.50") == 50
        //ips_between("10.0.0.0", "10.0.1.0") == 256
        //ips_between("20.0.0.10", "20.0.1.0") == 246

        string firstIP = Console.ReadLine();
        string secondIP = Console.ReadLine();

        long distanceBetween = IpsBetween(firstIP, secondIP);

        Console.WriteLine(distanceBetween);
    }

    public static long IpsBetween(string firstIP, string secondIP)
    {
        var ip1Array = firstIP.Split('.').Select(x => byte.Parse(x)).ToArray();
        var ip2Array = secondIP.Split('.').Select(x => byte.Parse(x)).ToArray();
        long result = 0;
        result += (ip2Array[0] - ip1Array[0]) * 256 * 256 * 256;
        result += (ip2Array[1] - ip1Array[1]) * 256 * 256;
        result += (ip2Array[2] - ip1Array[2]) * 256;
        result += (ip2Array[3] - ip1Array[3]);
        return result;
    }
}