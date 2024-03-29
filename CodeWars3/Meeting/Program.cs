﻿using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //https://www.codewars.com/kata/meeting/train/csharp

        //makes this string uppercase
        //gives it sorted in alphabetical order by last name.
        //When the last names are the same, sort them by first name.
        //Last name and first name of a guest come in the result between parentheses separated by a comma.

        //Ex: 
        //input = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        //output = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"

        string input = Console.ReadLine();
        var people = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToUpper()).ToList();

        var listOfCoworkers = new List<Coworker>();

        foreach (var person in people)
        {
            var names = person.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currentPerson = new Coworker()
            {
                firstName = names[0],
                lastName = names[1]
            };

            listOfCoworkers.Add(currentPerson);
        }

        listOfCoworkers = listOfCoworkers.OrderBy(x => x.lastName).ThenBy(x => x.firstName).ToList();
        var listOfNames = new List<string>();
        foreach (var worker in listOfCoworkers)
        {
            string currentName = $"({worker.lastName}, {worker.firstName})";
            listOfNames.Add(currentName);
        }

        string outPut = string.Join("", listOfNames);
        Console.WriteLine(outPut);
    }
}