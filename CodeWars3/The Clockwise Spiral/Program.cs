using System;
public class Program
{
    public static void Main()
    {
        // Classic definition: A spiral is a curve which emanates from a central point,
        //getting progressively farther away as it revolves around the point.

        //Your objective is to complete a function createSpiral(N) that receives an integer N and returns an NxN two-dimensional array,
        //with numbers 1 through NxN represented as a clockwise spiral.

        //Return an empty array if N < 1 or N is not int / number

        //Examples:
        //N = 3 Output: [[1, 2, 3],[8,9,4],[7,6,5]]

        //1    2    3    
        //8    9    4    
        //7    6    5    

        int N = int.Parse(Console.ReadLine());

        var outPut = MakeSpiral(N);

        PrintSpiral(outPut);
    }

    public static void PrintSpiral(int[,] matrix)
    {
        var rowCount = matrix.GetLength(0);
        var colCount = matrix.GetLength(1);
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
                Console.Write($"{matrix[row, col]} ");
            Console.WriteLine();
        }
    }

    public static int[,] MakeSpiral(int size)
    {
        int[,] matrix = new int[size, size];
        int count = 1;
        int currentSize = size;
        int iterationsNeeded = (int)Math.Ceiling(((float)size) / 2);
        for (int it = 0; it < iterationsNeeded; it++)
        {
            for (int i = 0 + it; i < size - it; i++)
            {
                matrix[it, i] = count;
                count++;
            }
            for (int i = 1 + it; i < size - 1 - it; i++)
            {
                matrix[i, size - 1 - it] = count;
                count++;
            }
            if (currentSize > 1)
            {
                for (int i = size - 1 - it; i >= it; i--)
                {
                    matrix[size - 1 - it, i] = count;
                    count++;
                }
            }
            for (int i = size - 2 - it; i > it; i--)
            {
                matrix[i, it] = count;
                count++;
            }
            currentSize -= 2;
        }
        return matrix;
    }
}