namespace FindAllPathsInALabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());
            char[,] labyrinth = new char[rowsCount, colsCount];

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();

                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    labyrinth[row, col] = symbols[col];
                }
            }

            FindAllPaths(labyrinth, 0, 0, new List<string>(), string.Empty);
        }

        static void FindAllPaths(char[,] labyrinth, int row, int col, List<string> path, string direction)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] == '*' || labyrinth[row, col] == 'v')
            {
                return;
            }

            path.Add(direction);

            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, path));
                path.RemoveAt(path.Count - 1);
                return;
            }
                
            labyrinth[row, col] = 'v';

            FindAllPaths(labyrinth, row - 1, col, path, "U"); //UP
            FindAllPaths(labyrinth, row + 1, col, path, "D"); //DOWN
            FindAllPaths(labyrinth, row, col + 1, path, "R"); //RIGHT
            FindAllPaths(labyrinth, row, col - 1, path, "L"); //LEFT

            path.RemoveAt(path.Count - 1);
            labyrinth[row, col] = '-';
        }
    }
}