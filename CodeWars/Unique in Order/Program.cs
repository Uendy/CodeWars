using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Implement the function unique_in_order which takes as argument a sequence and returns a list of items,
        //without any elements with the same value next to each other and preserving the original order of elements.

        //For example:
        //uniqueInOrder('AAAABBBCCDAABBB') == ['A', 'B', 'C', 'D', 'A', 'B']
        //uniqueInOrder('ABBCcAD') == ['A', 'B', 'C', 'c', 'A', 'D']
        //uniqueInOrder([1, 2, 2, 3, 3])       == [1, 2, 3]

        var input = Console.ReadLine().ToList();

        if (input.Count() == 0)
        {
            Environment.Exit(0);
        }

        var listOfCharsInOrder = new List<char>();
        listOfCharsInOrder.Add(input.First()); // have to add atleast one 

        int currentIndex = 0;

        for (int index = 0; index < input.Count(); index++)
        {
            if (listOfCharsInOrder[currentIndex] != input[index])
            {
                currentIndex++;
                listOfCharsInOrder.Add(input[index]);
            }
        }

        string outPut = string.Join(" ", listOfCharsInOrder);
        Console.WriteLine(outPut);
    }
}