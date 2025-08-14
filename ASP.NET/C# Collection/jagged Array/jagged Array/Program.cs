using System;

namespace Jagged_Array_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Part 1: Jagged array of 1D arrays ---
            Console.Write("Enter number of rows for 1D jagged array: ");
            int rows1D = int.Parse(Console.ReadLine());

            int[][] number1D = new int[rows1D][];

            for (int i = 0; i < rows1D; i++)
            {
                Console.Write($"Enter number of columns for row {i + 1}: ");
                int cols = int.Parse(Console.ReadLine());

                number1D[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Enter element [{i}][{j}]: ");
                    number1D[i][j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n1D Jagged Array Elements:");
            for (int i = 0; i < number1D.Length; i++)
            {
                for (int j = 0; j < number1D[i].Length; j++)
                {
                    Console.Write(number1D[i][j] + " ");
                }
                Console.WriteLine();
            }


            // --- Part 2: Jagged array of 2D arrays ---
            Console.Write("\nEnter number of outer rows for jagged 2D array: ");
            int rows2D = int.Parse(Console.ReadLine());

            int[][,] number2D = new int[rows2D][,];

            for (int i = 0; i < rows2D; i++)
            {
                Console.WriteLine($"\n--- For 2D array at index {i} ---");

                Console.Write("Enter number of rows for this 2D array: ");
                int r = int.Parse(Console.ReadLine());

                Console.Write("Enter number of columns for this 2D array: ");
                int c = int.Parse(Console.ReadLine());

                number2D[i] = new int[r, c];

                for (int x = 0; x < r; x++)
                {
                    for (int y = 0; y < c; y++)
                    {
                        Console.Write($"Enter element [{x},{y}]: ");
                        number2D[i][x, y] = int.Parse(Console.ReadLine());
                    }
                }
            }

            Console.WriteLine("\n--- Jagged 2D Array Output ---");
            for (int i = 0; i < rows2D; i++)
            {
                Console.WriteLine($"2D Array {i}:");
                int r = number2D[i].GetLength(0);
                int c = number2D[i].GetLength(1);

                for (int x = 0; x < r; x++)
                {
                    for (int y = 0; y < c; y++)
                    {
                        Console.Write(number2D[i][x, y] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
