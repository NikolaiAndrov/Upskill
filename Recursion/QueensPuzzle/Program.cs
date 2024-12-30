namespace QueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonal = new HashSet<int>();

        static void Main(string[] args)
        {
            bool[,] board = new bool[8,8];
            InsertQueens(board, 0);
        }

        static void InsertQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(1))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanInsertQueen(row, col))
                {
                    board[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonal.Add(row - col);
                    attackedRightDiagonal.Add(row + col);

                    InsertQueens(board, row + 1);

                    board[row, col] = false;
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonal.Remove(row - col);
                    attackedRightDiagonal.Remove(row + col);
                }
            }
        }

        static bool CanInsertQueen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                !attackedCols.Contains(col) && 
                !attackedLeftDiagonal.Contains(row - col) &&
                !attackedRightDiagonal.Contains(row + col);
        }

        static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row,col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
