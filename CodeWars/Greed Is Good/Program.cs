﻿using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Greed is a dice game played with five six - sided dice./
        //Your mission, should you choose to accept it, is to score a throw according to these rules.
        //You will always be given an array with five six-sided dice values.

        // Three 1's => 1000 points
        // Three 6's =>  600 points
        // Three 5's =>  500 points
        // Three 4's =>  400 points
        // Three 3's =>  300 points
        // Three 2's =>  200 points
        // One   1   =>  100 points
        // One   5   =>   50 point
        //A single die can only be counted once in each roll. 
        //For example, a "5" can only count as part of a triplet(contributing to the 500 points) or as a single 50 points,
        //but not both in the same roll.

        //Example scoring
        // Throw Score
        // ---------------------------
        // 5 1 3 4 1   50 + 2 * 100 = 250
        // 1 1 1 3 1   1000 + 100 = 1100
        // 2 4 4 5 4   400 + 50 = 450

        //ToDo: try a class dice and print 5 objects;
        //TODO: Learn Group By and Sort

        string input = Console.ReadLine();

        var dice = input.Split(' ').Select(int.Parse).ToArray();

        //change all 1's to 10's, easier to add the score later on
        for (int index = 0; index < dice.Count(); index++)
        {
            if (dice[index] == 1)
            {
                dice[index] = 10;
            }
        }

        //create and populate the dice as list so they can be grouped by their value
        var listOfDice = new List<Die>();

        for (int index = 0; index < dice.Count(); index++)
        {
            var currentDie = new Die()
            {
                value = dice[index]
            };

            listOfDice.Add(currentDie);
        }

        var groups = listOfDice.GroupBy(Die => new { Die.value }).OrderByDescending(x => x.Count()).ToList();

        int score = 0;

        bool quintuple = groups.Count() == 1;
        if (quintuple)
        {
            bool onlyOnes = int.Parse(groups[0].Key.ToString()) == 10;
            if (onlyOnes)
            {
                score += 1200;
            }
        }
    }
}