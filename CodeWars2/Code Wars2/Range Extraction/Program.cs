﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //A format for expressing an ordered list of integers is to use a comma separated list of either individual integers
        //or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'.
        //The range includes all integers in the interval including both endpoints.
        //It is not considered a range unless it spans at least 3 numbers.For example("12, 13, 15-17")
        //Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.

        //Example:
        //solution([-6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
        // returns "-6,-3-1,3-5,7-11,14,15,17-20"

        //so all the ones that have more than 1 between them return as the same ex: -5, -2, 0 -> -5, -2, 0
        //all those that are subsequent insert into a range ex: -3, -2, -1, 0, 1 -> -3-1
    }
}