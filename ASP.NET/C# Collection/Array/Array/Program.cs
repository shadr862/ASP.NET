using System;

class Program
{
    static void Main()
    {
        // 1D Integer array
        Console.Write("Enter number of integers: ");
        int[] numbers = new int[Convert.ToInt32(Console.ReadLine())];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter integer {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("\nIntegers entered:");
        foreach (var num in numbers)
            Console.WriteLine(num);
        Console.WriteLine($"Rank of integer array: {numbers.Rank}";


        // 1D String array
        Console.Write("\nEnter number of strings: ");
        string[] words = new string[Convert.ToInt32(Console.ReadLine())];

        for (int i = 0; i < words.Length; i++)
        {
            Console.Write($"Enter string {i + 1}: ");
            words[i] = Console.ReadLine();
        }

        Console.WriteLine("\nStrings entered:");
        foreach (var word in words)
            Console.WriteLine(word);
        Console.WriteLine($"Rank of string array: {words.Rank}");



        // 2D array
        Console.Write("\nEnter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"Enter element [{i},{j}]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\nMatrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
        Console.WriteLine($"Rank of 2D array: {matrix.Rank}");



        // 3D array
        Console.Write("\nEnter depth (pages): ");
        int depth = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of rows: ");
        int rows3D = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols3D = Convert.ToInt32(Console.ReadLine());

        int[,,] cube = new int[depth, rows3D, cols3D];

        for (int d = 0; d < cube.GetLength(0); d++)
        {
            for (int r = 0; r < cube.GetLength(1); r++)
            {
                for (int c = 0; c < cube.GetLength(2); c++)
                {
                    Console.Write($"Enter element [{d},{r},{c}]: ");
                    cube[d, r, c] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        Console.WriteLine("\n3D Array Elements:");
        for (int d = 0; d < cube.GetLength(0); d++)
        {
            Console.WriteLine($"\nPage {d + 1}:");
            for (int r = 0; r < cube.GetLength(1); r++)
            {
                for (int c = 0; c < cube.GetLength(2); c++)
                    Console.Write(cube[d, r, c] + "\t");
                Console.WriteLine();
            }
        }
        Console.WriteLine($"Rank of 3D array: {cube.Rank}");

       
        
    }
}
