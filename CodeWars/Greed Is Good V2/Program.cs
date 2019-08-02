using System;
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

        string input = Console.ReadLine();

        var dice = input.Split(' ').Select(int.Parse).ToArray();

        var sideAndOccurance = new Dictionary<int, int>(); // key == value, value == occurances
        foreach (var die in dice)
        {
            bool newValue = !sideAndOccurance.ContainsKey(die);
            if (newValue)
            {
                sideAndOccurance[die] = 1;
            }
            else //new value
            {
                sideAndOccurance[die]++;
            }
        }

        int score = 0;

        var keys = sideAndOccurance.Keys;

        for (int dieSides = 1; dieSides <= 6; dieSides++)
        {
            bool keyExists = sideAndOccurance.ContainsKey(dieSides);
            if (keyExists)
            {
                bool overThreeOccurances = sideAndOccurance[dieSides] >= 3;
                if (overThreeOccurances)
                {
                    if (dieSides == 1)
                    {
                        score += 1000;
                    }
                    else
                    {
                        score += dieSides * 100;
                    }

                    sideAndOccurance[dieSides] -= 3;
                }
            }
        }

        bool containsOne = sideAndOccurance.ContainsKey(1);
        if (containsOne)
        {
            int numberOfOnesLeftOver = sideAndOccurance[1];
            int bonusFromOnes = numberOfOnesLeftOver * 100;
            score += bonusFromOnes;
        }

        bool containsFive = sideAndOccurance.ContainsKey(5);
        if (containsFive)
        {
            int numberOfFivesLeftOver = sideAndOccurance[5];
            int bonusFromFives = numberOfFivesLeftOver * 50;
            score += bonusFromFives;
        }

        Console.WriteLine(score);

        //clever solution:
        //private static int[] _threes = new int[] { 0, 1000, 200, 300, 400, 500, 600 };
        //private static int[] _singles = new int[] { 0, 100, 0, 0, 0, 50, 0 };
        //public static int Score(int[] dice)
        //{
        //    return dice
        //        .GroupBy(d => d)
        //        .Select(gr => new { num = gr.Key, count = gr.Count() })
        //        .Sum(n => (n.count / 3) * _threes[n.num] + (n.count % 3) * _singles[n.num]);
        //}

        //The way I wanted to do it: (by grouping them)
        //public static int Score(int[] dice) 
        //{
        //    return dice
        //      .GroupBy(d => d)
        //      .Select(g => Points(g.Key, g.Count()))
        //      .Sum();
        //}
        //
        //private static int Points(int die, int count)
        //{
        //    switch (die)
        //    {
        //        case 1:
        //            return (count / 3) * 1000 + (count % 3) * 100;
        //        case 5:
        //            return (count / 3) * 500 + (count % 3) * 50;
        //        default:
        //            return (count / 3) * die * 100;
        //    }
    }
}