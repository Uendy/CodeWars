﻿using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        #region
        //Task:
        //our task is to make a simple class called SnakesLadders. 
        //The test cases will call the method play(die1, die2) independantly of the state of the game or the player turn. 
        //The variables die1 and die2 are the die thrown in a turn and are both integers between 1 and 6. 
        //The player will move the sum of die1 and die2.

        //Rules:
        //1.There are two players and both start off the board on square 0.
        //2.Player 1 starts and alternates with player 2.
        //3.You follow the numbers up the board in order 1=>100
        //4.If the value of both die are the same then that player will have another go.
        //5.Climb up ladders. The ladders on the game board allow you to move upwards and get ahead faster.
        //If you land exactly on a square that shows an image of the bottom of a ladder, then you may move the player all the way up to the square at the top of the ladder. (even if you roll a double).
        //6.Slide down snakes. Snakes move you back on the board because you have to slide down them.
        //If you land exactly at the top of a snake, slide move the player all the way to the square at the bottom of the snake or chute. (even if you roll a double).
        //7.Land exactly on the last square to win.The first person to reach the highest square on the board wins. 
        //But there's a twist! If you roll too high, your player "bounces" off the last square and moves back. 
        //You can only win by rolling the exact number needed to land on the last square. 
        //For example, if you are on square 98 and roll a five, move your game piece to 100 (two moves), 
        //then "bounce" back to 99, 98, 97 (three, four then five moves.)

        //Returns
        //Return Player n Wins!.Where n is winning player that has landed on square 100 without any remainding moves left.
        //Return Game over! if a player has won and another player tries to play.
        //Otherwise return Player n is on square x.Where n is the current player and x is the sqaure they are currently on.
        #endregion

        //My spin on it:
        //Decided to randomize the die instead of inputting them each time
        //and printing the whole game on the console

        var random = new Random();

        var snakesAndLadders = new Dictionary<int, int>()
        {
            [2] = 38, // kadders
            [7] = 14,
            [8] = 31,
            [15] = 26,
            [21] = 42,
            [28] = 84,
            [36] = 44,
            [51] = 67,
            [71] = 91,
            [78] = 98,
            [87] = 94,
            [16] = 6, // snakes
            [46] = 25,
            [49] = 11,
            [62] = 19,
            [64] = 60,
            [74] = 53,
            [89] = 68,
            [92] = 88,
            [99] = 80
        };

        int playerOne = 1;
        int playerTwo = 1;

        for (int turn = 0; playerOne != 100 && playerTwo != 100; turn++)
        {
            int firstDie = random.Next(1, 7);
            int secondDie = random.Next(1, 7);

            if (turn % 2 == 0) // p1 turn
            {
                Console.Write($"PlayerOne rolls: [{firstDie}] and [{secondDie}] from position {playerOne}");
                playerOne = MovePiece(playerOne, firstDie, secondDie, snakesAndLadders);
                Console.WriteLine($" and moves to {playerOne}");
            }
            else //p2 turn
            {
                Console.Write($"PlayerTwo rolls: [{firstDie}] and [{secondDie}] from position {playerTwo}");
                playerTwo = MovePiece(playerTwo, firstDie, secondDie, snakesAndLadders);
                Console.WriteLine($" and moves to {playerTwo}");
            }

            if (firstDie == secondDie)
            {
                turn += 1; // or two to allow for a 2nd move when dice the same
            }
        }

        Console.WriteLine("+-----------------------------------------------+");
        if (playerOne == 100)
        {
            Console.WriteLine("PlayerOne wins!");
        }
        else // playerTwoOne
        {
            Console.WriteLine("PlayerTwo wins!");
        }

        Console.WriteLine($"Final Score: PlayerOne = {playerOne} and playerTwo = {playerTwo}");
    }

    public static int MovePiece(int initialPosition, int firstDie, int secondDie, Dictionary<int, int> snakesAndLadders)
    {
        int newPosition = initialPosition + firstDie + secondDie;

        bool gameOver = newPosition == 100;
        if (gameOver)
        {
            return 100;
        }

        bool pentalty = newPosition >= 101;
        if (pentalty)
        {
            int pointDeduction = newPosition - 100;
            newPosition = 100 - pointDeduction;
        }

        bool snakeOrLadder = snakesAndLadders.ContainsKey(newPosition);
        if (snakeOrLadder)
        {
            newPosition = snakesAndLadders[newPosition];
        }

        return newPosition;
    }
}