﻿using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Link to Kata: codewars.com/kata/5531abe4855bcc8d1f00004c/train/csharp

        #region
        //In the game of ten - pin bowling, a player rolls a bowling ball down a lane to knock over pins.
        //There are ten pins set at the end of the bowling lane. Each player has 10 frames to roll a bowling ball down a lane and knock over as many pins as possible.
        //The first nine frames are ended after two rolls or when the player knocks down all the pins.
        //The last frame a player will receive an extra roll every time they knock down all ten pins; up to a maximum of three total rolls.

        //The Challenge
        //In this challenge you will be given a string representing a player's ten frames. It will look something like this: 'X X 9 / 80 X X 90 8 / 7 / 44', 
        //where each frame is space-delimited, 'X' represents strikes, and ' / ' represents spares. 
        //Your goal is take in this string of frames into a function called bowlingScore and return the players total score.

        //Scoring
        //The scoring for ten - pin bowling can be difficult to understand, and if you're like most people, easily forgotten if you don't play often.
        //Here is a quick breakdown:

        //Frames
        //In Ten - Pin Bowling there are ten frames per game.Frames are the players turn to bowl, which can be multiple rolls.
        //The first 9 frames you get 2 rolls maximum to try to get all 10 pins down. 
        //On the 10th or last frame a player will receive an extra roll each time they get all ten pins down to a maximum of three total rolls. 
        //Also on the last frame bonuses are not awarded for strikes and spares moving forward.

        //In this challenge, three frames might be represented like this: 54 72 44.
        //In this case, the player has had three frames.
        //On their first frame they scored 9 points(5 + 4), on their second frame they scored 9 points(7 + 2) and on their third frame they scored 8 points(4 + 4).
        //This is a very simple example of bowling scoring.It gets more complicated when we introduce strikes and spares.

        //Strikes
        //Represented in this challenge as 'X'
        //A strike is scored when a player knocks all ten pins down in one roll.
        //In the first 9 frames this will conclude the players turn and it will be scored as 10 points plus the points received from the next two rolls.
        //So if a player were to have two frames X 54, the total score of those two frames would be 28.
        //The first frame would be worth 19(10 + 5 + 4) and the second frame would be worth 9(5 + 4).

        //A perfect game in bowling is 12 strikes in a row and would be represented like this 'X X X X X X X X X XXX'
        //This adds up to a total score of 300.

        //Spares
        //Represented in this challenge as '/'
        //A spare is scored when a player knocks down all ten pins in two rolls. In the first 9 frames this will be scored as 10 points plus the next roll.
        //So if a player were to have two frames 9 / 54, the total score of the two frames would be 24.
        //The first frame would be worth 15(10 + 5) and the second frame would be worth 9(5 + 4).
        #endregion

        string input = Console.ReadLine();

        int score = CalculateScore(input);
        Console.WriteLine(score);
    }

    public static int CalculateScore(string input)
    {
        //get the frames
        var frames = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        int score = 0;

        bool strike = false;
        bool spare = false;

        int carryOver = 0;

        for (int i = 0; i < frames.Count(); i++)
        {
            int currentFrameScore = 0;

            var bowl = frames[i].ToCharArray(); // get each bowl

            for (int roll = 0; roll < bowl.Count(); roll++)
            {
                bool isStrike = bowl[roll] == 'X';
                if (isStrike)
                {
                    //currentFrameScore += 10;
                    carryOver += 10;
                    bool multipleStrikes = strike == true;
                    if (multipleStrikes)
                    {
                        carryOver += 10;
                        //currentFrameScore *= 2;
                        bool turkey = carryOver > 30; // 3 or more strikes
                        if (turkey)
                        {
                            currentFrameScore += 30;
                            carryOver -= 10;
                        }
                    }
                    strike = true;
                    continue;
                }

                bool isSpare = bowl[roll] == '/';
                if (isSpare)
                {
                    currentFrameScore = 10;
                    bool bonus = strike == true || spare == true;
                    if (bonus)
                    {
                        currentFrameScore *= 2;
                    }
                    spare = true;
                    continue;
                }

                int currentRoll = int.Parse(bowl[roll].ToString()); // get the current roll score

                bool previoisStrike = strike == true; //checking and adding strike bonus
                if (previoisStrike)
                {
                    int bonus = currentRoll *= carryOver / 10;
                    currentFrameScore += bonus;
                    currentFrameScore += carryOver;
                    carryOver = 0;
                    //currentRoll *= 2;
                }

                bool previoisSpare = spare == true && roll == 0; // checking and adding strike bonus only to first roll
                if (previoisSpare)
                {
                    currentRoll *= 2;
                }

                currentFrameScore += currentRoll;

                strike = false; // returning both to false as the bonus has been given
                spare = false;
            }

            score += currentFrameScore;
        }

        return score;

    }
}