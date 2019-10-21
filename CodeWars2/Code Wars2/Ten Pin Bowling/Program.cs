using System;
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

        string frames = Console.ReadLine();

        int score = CalculateScore(frames);
        Console.WriteLine(score);
    }

    public static int CalculateScore(string frames)
    {
        int score = 0;

        //get each throw result indevidually
        var throws = frames.ToCharArray().Where(x => x != ' ').Select(y => y.ToString()).ToArray();

        //go forwards to add bonus when needed, but be careful if you get to the last 2 throws
        for (int index = 0; index < throws.Count(); index++)
        {
            var currentThrow = throws[index];

            bool normalThrow = int.TryParse(currentThrow, out int points);
            if (normalThrow)
            {
                score += points;
                continue;
            }

            bool strike = currentThrow == "X";
            if (strike)
            {
                // if there are more than 2 shots
                if (index < throws.Count() - 2)
                {
                    var nextShot = throws[index + 1];
                    var secondShot = throws[index + 2];

                    bool turkey = nextShot == "X" && secondShot == "X"; // both are strikes -> 10 + 10 + 10
                    if (turkey)
                    {
                        score += 30;
                        continue;
                    }

                    bool anotherStrike = nextShot == "X" || secondShot == "X"; // atleast one is strike -> 10 + (10 + [1-9])
                    if (anotherStrike)
                    {
                        // see which one is strike and add the other one
                        if (nextShot == "X")
                        {
                            int secondShotPoints = int.Parse(secondShot);
                            score += 20 + secondShotPoints;
                        }
                        else //secondShot == "X";
                        {
                            int nextShotPoints = int.Parse(nextShot);
                            score += 20 + nextShotPoints;
                        }
                        continue;
                    }

                    bool secondIsSpare = secondShot == "/"; // strike, normal points, then spare -> 10 + [1-9] + 10-[1-9]
                    if (secondIsSpare)
                    {
                        //int nextShotPoints = int.Parse(nextShot);
                        score += 20;
                        continue;
                    }

                    // no spars or strike
                    int firstShotPoints = int.Parse(nextShot);
                    int lastShotPoints = int.Parse(secondShot);

                    score += 10 + firstShotPoints + lastShotPoints;
                    continue;
                }

                // if there is one more shot
                if (index < throws.Count() - 1)
                {
                    var nextShot = throws[index + 1];
                    if (nextShot == "X") // if strike
                    {
                        score += 20;
                    }
                    else // non strike, [1-9]
                    {
                        int nextPoints = int.Parse(nextShot);
                        score += 10 + nextPoints;
                    }
                }

                //if strke = the last shot
                if (index == throws.Count() - 1)
                {
                    score += 10;
                }
            }

            bool spare = currentThrow == "/";
            if (spare)
            {
                score -= int.Parse(throws[index - 1]); // to ge tthe full ten point from the spare, - this points you got from the last throw;
                bool notLast = index < throws.Count() - 2;
                if (notLast)
                {
                    var nextThrow = throws[index + 1];
                    if (nextThrow == "X") // score a strike the next one, +10 from spare and + 10 from strike, cant land  a spare as thats atleast 2 throws away
                    {
                        score += 20;
                    }
                    else // normal throws, 10 from spare + whatever you get from the next throw that isnt a special throw
                    {
                        if (index != throws.Count() - 2)
                        {
                            score += 10 + int.Parse(nextThrow);
                        }
                        else
                        {
                            score += 10; // as the last frame spare dosent give the bonus
                        }
                    }
                }
                else // last throw of game
                {
                    score += 10;
                }
            }
        }

        //My score was off, because the last frame dosent count the spare and strike bonuses, so here I search for them and remove them
        string lastFrame = frames.Split(' ').Last().ToString();
        
        bool lastFrameTurkey = lastFrame == "XXX";
        if (lastFrameTurkey)
        {
            score -= 30;
            return score;
        }

        //check if the last frame starts with a strike, if it does, then take off the bonus for the next 2 shots by minusing them from the total
        var lastFrameBowls = lastFrame.ToCharArray();
        bool lastFrameStrike = lastFrameBowls[0] == 'X';
        if (lastFrameStrike)
        {
            string penultimateThrow = lastFrameBowls[1].ToString();
            string lastThrow = lastFrameBowls[2].ToString();

            if (lastFrameBowls[1] == 'X' || lastFrameBowls[2] == 'X')
            {
                score -= 10;

                // /X8 -> score -= 8
                bool penultimateIsStrike = int.TryParse(penultimateThrow, out int penultimatePoints);
                if (penultimateIsStrike)
                {
                    score -= penultimatePoints;
                }
                else
                {
                    int lastPoints = int.Parse(lastThrow);
                    score -= lastPoints;
                }
            }
            else // no more strikes, so subtract [1] and [2] from score
            {
                int lastPoints = int.Parse(lastThrow);
                int penPoints = int.Parse(penultimateThrow);
                score -= lastPoints;
                score -= penPoints;
            }
        }

        //if the 2nd throw [1] == strike, then take away the last throw bonus score -= int.Parse([2])
        bool secondIsStrike = lastFrameBowls[1] == 'X';
        if (secondIsStrike)
        {
            int lastPoints = int.Parse(lastFrameBowls[2].ToString());
            score -= lastPoints;
            return score;
        }

        return score;
    }
}