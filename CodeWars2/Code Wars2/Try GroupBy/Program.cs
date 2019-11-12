using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a function that takes an array and counts the number of each unique element present.

        var list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        foreach (var line in list.GroupBy(x => x)
                        .Select(group => new
                        {
                            name = group.Key,
                            Count = group.Count()
                        }))
        {
            Console.WriteLine($"{line.name} - {line.Count}");
        }
    }
}