using System;
using System.Linq;
using System.Text;

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

        string input = Console.ReadLine();
        var args = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var solution = TruncateRange(args);

        Console.WriteLine(solution);
    }

    public static string TruncateRange(int[] args)
    {
        var array = args.ToList();

        bool notRange = array.Count() < 3; //it is not considered a range unless it spans at least 3 numbers.
        if (notRange)
        {
            return string.Join(",", array);
        }

        var sb = new StringBuilder();

        for (int index = 0; index < array.Count(); index++)
        {
            bool lastTwoNums = index >= array.Count - 2; // see if this works with 1 remaining in range
            if (lastTwoNums) // if you are on the second to last, or last index, put them in a range, add the comma (if needed) and append to sb
            {
                int remainingCount = array.Count() - index;
                var remainingRange = array.GetRange(index, remainingCount);
                var stringRemaning = string.Join(",", remainingRange);

                sb.Append(stringRemaning);
                break;
            }

            int startNum = array[index];
            int seqNum = array[index + 2];

            bool isRange = seqNum - startNum == 2; // minimum for a sequence, see how long it goes
            if (isRange)
            {
                bool lastNum = index + 2 == array.Count() - 1; // make the final sequence return the sb
                if (lastNum)
                {
                    sb.Append($"{startNum}-{seqNum}");
                    break;
                }

                for (int innerIndex = index + 3; innerIndex < array.Count(); innerIndex++)
                {
                    int nextNum = array[innerIndex];

                    bool continueSeq = nextNum - startNum == innerIndex - index; 
                    if (!continueSeq) // append these numbers as a sequence and update the index to the current innerIndex
                    {
                        int endOfNum = array[innerIndex - 1]; // get the last num in the sequence
                        sb.Append($"{startNum}-{endOfNum},");

                        index = innerIndex - 1; // give it the index of the endNum, as the for-cycle will move itself to the next num
                        break;
                    }

                    bool lastIndex = innerIndex == array.Count() - 1;
                    if (lastIndex)
                    {
                        sb.Append($"{startNum}-{nextNum}");
                        string outPut = sb.ToString();
                        return outPut;
                    }
                }
            }
            else // not a range, so appent it as a non-seq num and move onto the next
            {
                sb.Append($"{startNum},");
            }

        }

        string output = sb.ToString();
        return output;
    }
}